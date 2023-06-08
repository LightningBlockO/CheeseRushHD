using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLap2 : MonoBehaviour
{
    public GameObject lap2;
    private void Start()
    {
        lap2.SetActive(false);
    }
}
