using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static Score Instance { get; private set; }
    public int coin = 0;
    public int score = 0;
    public int highScore = 0;
    public int currentScore = 0;
    public ScoreUI scoreUI;
    public GameObject ScoreCanvas;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        ScoreCanvas.SetActive(false);
        AddScore(0);
    }
    public void AddScore(int Score)
    {

        coin = PlayerPrefs.GetInt("Coin", 0);
        coin += Score;
        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.Save();

        score += Score;
        currentScore = score;

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
        }
    }
    public void Scorereset()
    {
        Score.Instance.currentScore = 0;
        Score.Instance.score = 0;
    }

}

