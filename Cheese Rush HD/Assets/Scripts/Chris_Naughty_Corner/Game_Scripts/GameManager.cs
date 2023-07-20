using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] CheeseCollect cheesecollect;
    [SerializeField] TextMeshProUGUI highscoreText;
    int score;

    void cheese()
    {
        CheckHighScore();
        Debug.Log("updated Highscore");
    }
    void CheckHighScore()
    {

        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        //Only On Downlaoded COmputer
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.GetInt("HighScore");
    }

    void UpdateHighScoreText()
    {
        highscoreText.text = $"Highscore:{PlayerPrefs.GetInt("Highscore", 0)}";
    }

}
