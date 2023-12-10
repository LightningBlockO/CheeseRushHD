using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenuAgain : MonoBehaviour
{
    private void Start()
    {
        Invoke("GoToMenu", 72f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            SceneManager.LoadScene("Menu Scene");
        }
    }
    void GoToMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
}
