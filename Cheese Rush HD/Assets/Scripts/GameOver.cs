using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Start()
    {
        Invoke("GoToMenu", 5);
    }
    void GoToMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
}
