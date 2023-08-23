using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Load the saved score from PlayerPrefs
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);

        // Update the UI element with the loaded score
        scoreText.text = "Score: " + currentScore.ToString();
    }
}