using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    private void Start()
    {
        Invoke("GoToMenu", 50f);
    }
    void GoToMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            SceneManager.LoadScene("Menu Scene");
        }
    }
}
