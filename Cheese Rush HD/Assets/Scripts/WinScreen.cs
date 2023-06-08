using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject remystill;
    public GameObject remyslide;
    public GameObject remyenter;
    public GameObject textslide;
    private void Start()
    {
        Invoke("RemySlide", 3);
        Invoke("RemyEnter", 3.8f);
        Invoke("GoToMenu", 14);
    }
    void RemySlide()
    {
        remystill.SetActive(false);
        remyslide.SetActive(true);
    }
    void RemyEnter()
    {
        remyenter.SetActive(true);
        textslide.SetActive(true);
    }
    void GoToMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
}
