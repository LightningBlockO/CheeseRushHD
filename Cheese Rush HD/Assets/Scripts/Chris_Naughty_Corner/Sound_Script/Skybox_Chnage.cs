using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox_Chnage : MonoBehaviour
{
    public Material skyboxLevel1;
    public Material skyboxLevel2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Rat"))
        {
            RenderSettings.skybox = skyboxLevel2;
            Destroy(gameObject);
        }
    }
}
