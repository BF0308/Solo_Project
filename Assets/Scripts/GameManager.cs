using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ReStart; //리스타트 텍스트가 들어갈 공간
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }//싱글톤 적용


    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject); // 중복 방지
        }
    }
    private void Start()
    {
        if (ReStart == null)//리스타트값이 비어있으면
            Debug.LogError("restart is null");//에러로그 출력
        Score.Instance.ScoreCanvas.SetActive(false);
        ReStart.gameObject.SetActive(false); //리스타트 오브젝트를 끈다.
    }
    public void GameOver()
    {
        Debug.Log("GameOver");//로그에 게임오버남기기
        Score.Instance.ScoreCanvas.SetActive(true);
        SetRestart();//uiManager에 리스타트UI띄워주는 메서드 실행
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//현재씬 이름을 가져와서 로드한다 (재시작)
    }


    private void SetRestart()//리스타트 메서드
    {
        ReStart.gameObject.SetActive(true); //리스타트 오브젝트를 킨다.
    }

}
