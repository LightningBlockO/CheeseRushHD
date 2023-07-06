using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject player;
    public GameObject cheeseFace;
    public float timeRemaining = 230;
    private bool timerRunning = true;
    public TextMeshProUGUI timeText;

    void Update()
    {
        DoTimer();
    }
    public void DisplayTimer(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void DoTimer()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTimer(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                cheeseFace.SetActive(true);
                Instantiate(cheeseFace, player.transform.position, Quaternion.identity);
                cheeseFace.transform.parent = player.transform;
                //SceneManager.LoadScene("Lose Scene");
            }
        }
    }
}
