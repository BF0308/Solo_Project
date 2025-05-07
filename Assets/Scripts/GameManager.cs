using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //scoreText ������Ʈ�� �� ����
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
        if (scoreText == null)//���ھ�� ���������
            Debug.LogError("score text is null");//�����α� ���

        ReStart.gameObject.SetActive(false); //����ŸƮ ������Ʈ�� ����.
        UpdateScore();//���ھ� �ʱ�ȭ
    }
    public void GameOver()
    {
        Debug.Log("GameOver");//�α׿� ���ӿ��������
        SetRestart();//uiManager�� ����ŸƮUI����ִ� �޼��� ����
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//����� �̸��� �����ͼ� �ε��Ѵ� (�����)
    }

    public void AddScore()
    {
        UpdateScore();//���ھ��ؽ�Ʈ�� �����Ű�� �޼��� ȣ��
    }

    private void SetRestart()//����ŸƮ �޼���
    {
        ReStart.gameObject.SetActive(true); //����ŸƮ ������Ʈ�� Ų��.
    }
    private void UpdateScore()//���ھ������Ʈ �޼���
    {
        scoreText.text = PlayerPrefs.GetInt("Coin").ToString();//�޾ƿ� int�� ���ھ ��Ʈ�������� �ٲ� �ؽ�Ʈ�� �����Ų��.
    }
}
