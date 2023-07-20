using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    private int highScore;
    private int currentScore;
    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;

    private void Start()
    {
        LoadHighScore();
        DontDestroyOnLoad(gameObject);
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void UpdateUI()
    {
        currentScoreText.text = "CurrentScore: " + currentScore;
        highScoreText.text = "HighScore: " + highScore;
    }

    public void UpdateScore(int points)
    {
        currentScore += points;

        // Check if the current score beats the high score
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }

        UpdateUI();
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void GameOver()
    {
        SaveHighScore();
    }

}
