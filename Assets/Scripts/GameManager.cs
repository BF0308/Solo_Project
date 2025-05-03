using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //scoreText 오브젝트가 들어갈 공간
    public TextMeshProUGUI restartText; //리스타트 텍스트가 들어갈 공간
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }//싱글톤 적용

    private int currentScore = 0;//현재스코어 0으로초기화

    private void Awake()
    {
        gameManager = this;//게임오브젝트 클래스를 gameManager라는 함수에 저장(복제된 단하나의 싱글톤 선언)
    }
    private void Start()
    {
        if (restartText == null)//리스타트값이 비어있으면
            Debug.LogError("restart text is null");//에러로그 출력
        if (scoreText == null)//스코어값이 비어있으면
            Debug.LogError("score text is null");//에러로그 출력

        restartText.gameObject.SetActive(false); //리스타트 오브젝트를 끈다.
        UpdateScore(0);//스코어 초기화
    }
    public void GameOver()
    {
        Debug.Log("GameOver");//로그에 게임오버남기기
        SetRestart();//uiManager에 리스타트UI띄워주는 메서드 실행
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//현재씬 이름을 가져와서 로드한다 (재시작)
    }

    public void AddScore(int score)
    {
        currentScore += score;//받아온 스코어를 현재스코어 더해준다.
        Debug.Log("Score :" + currentScore);//확인용 로그
        UpdateScore(currentScore);//스코어텍스트를 변경시키는 메서드 호출
    }

    private void SetRestart()//리스타트 메서드
    {
        restartText.gameObject.SetActive(true); //리스타트 오브젝트를 킨다.
    }
    private void UpdateScore(int score)//스코어업데이트 메서드
    {
        scoreText.text = score.ToString();//받아온 int형 스코어를 스트링형으로 바꿔 텍스트에 적용시킨다.
    }
}
