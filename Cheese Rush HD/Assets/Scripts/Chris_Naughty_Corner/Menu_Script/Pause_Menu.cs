using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public  Player_Movement rat;
    void Start()
    {
        rat.GetComponent<Player_Movement>();
        //UnlockMouse();
        pauseMenu.SetActive(false);

    }
    //void UnlockMouse()
    //{
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            rat.GetComponent<Player_Movement>().enabled = false;
            pauseMenu.SetActive(true);
        }
        if (Input.GetKey(KeyCode.R))
        {
            pauseMenu.SetActive(false);
            rat.GetComponent<Player_Movement>().enabled = true;
        }
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("Menu Scene");
        }
        if (Input.GetKey(KeyCode.L))
        {
            Application.Quit();
        }

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
