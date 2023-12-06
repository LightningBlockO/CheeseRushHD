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
}
