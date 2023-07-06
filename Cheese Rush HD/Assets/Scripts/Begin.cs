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
            SceneManager.LoadScene("CRHD Prototype");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("Test_Kitchen");
        }
    }
}
