using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Switch : MonoBehaviour
{
    public GameObject audioLevel1;
    public GameObject audioLevel2;
    public Material skyboxLevel1;
    public Material skyboxLevel2;

    void Awake()
    {
        audioLevel2.SetActive(false);
        RenderSettings.skybox = skyboxLevel1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Rat"))
        {
            audioLevel1.SetActive(false);
            audioLevel2.SetActive(true);
            RenderSettings.skybox = skyboxLevel2;
            Destroy(gameObject);
        }
    }
}
