using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinText;
    Score score;
    private void Start()
    {
        score = Score.Instance;
        UpdateScoreUI();
    }
    public void UpdateScoreUI()
    {
        if (currentScoreText != null)
            currentScoreText.text = "Score: " + score.currentScore;

        if (highScoreText != null)
            highScoreText.text = "BestScore: " + score.highScore;

        if (coinText != null)
            coinText.text = score.coin.ToString();
    }

}
