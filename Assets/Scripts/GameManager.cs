using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ReStart; //����ŸƮ �ؽ�Ʈ�� �� ����
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }//�̱��� ����


    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }
    private void Start()
    {
        if (ReStart == null)//����ŸƮ���� ���������
            Debug.LogError("restart is null");//�����α� ���
        Score.Instance.ScoreCanvas.SetActive(false);
        ReStart.gameObject.SetActive(false); //����ŸƮ ������Ʈ�� ����.
    }
    public void GameOver()
    {
        Debug.Log("GameOver");//�α׿� ���ӿ��������
        Score.Instance.ScoreCanvas.SetActive(true);
        SetRestart();//uiManager�� ����ŸƮUI����ִ� �޼��� ����
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//����� �̸��� �����ͼ� �ε��Ѵ� (�����)
    }


    private void SetRestart()//����ŸƮ �޼���
    {
        ReStart.gameObject.SetActive(true); //����ŸƮ ������Ʈ�� Ų��.
    }

}
