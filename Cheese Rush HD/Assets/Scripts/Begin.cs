using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            SceneManager.LoadScene("Stage 1 - Kitchen");
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("Credits");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    SceneManager.LoadScene("Stage 2 - Neighbourhood");
        //}
    }
}
