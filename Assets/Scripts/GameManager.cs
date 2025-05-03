using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //scoreText ������Ʈ�� �� ����
    public TextMeshProUGUI restartText; //����ŸƮ �ؽ�Ʈ�� �� ����
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }//�̱��� ����

    private int currentScore = 0;//���罺�ھ� 0�����ʱ�ȭ

    private void Awake()
    {
        gameManager = this;//���ӿ�����Ʈ Ŭ������ gameManager��� �Լ��� ����(������ ���ϳ��� �̱��� ����)
    }
    private void Start()
    {
        if (restartText == null)//����ŸƮ���� ���������
            Debug.LogError("restart text is null");//�����α� ���
        if (scoreText == null)//���ھ�� ���������
            Debug.LogError("score text is null");//�����α� ���

        restartText.gameObject.SetActive(false); //����ŸƮ ������Ʈ�� ����.
        UpdateScore(0);//���ھ� �ʱ�ȭ
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

    public void AddScore(int score)
    {
        currentScore += score;//�޾ƿ� ���ھ ���罺�ھ� �����ش�.
        Debug.Log("Score :" + currentScore);//Ȯ�ο� �α�
        UpdateScore(currentScore);//���ھ��ؽ�Ʈ�� �����Ű�� �޼��� ȣ��
    }

    private void SetRestart()//����ŸƮ �޼���
    {
        restartText.gameObject.SetActive(true); //����ŸƮ ������Ʈ�� Ų��.
    }
    private void UpdateScore(int score)//���ھ������Ʈ �޼���
    {
        scoreText.text = score.ToString();//�޾ƿ� int�� ���ھ ��Ʈ�������� �ٲ� �ؽ�Ʈ�� �����Ų��.
    }
}
