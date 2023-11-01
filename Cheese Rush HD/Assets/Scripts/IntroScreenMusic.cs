using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreenMusic : MonoBehaviour
{
    public GameObject intromusic;
    private void Start()
    {
        Invoke("StartMusic", 3);
    }
    void StartMusic()
    {
        intromusic.SetActive(true);
    }
}
