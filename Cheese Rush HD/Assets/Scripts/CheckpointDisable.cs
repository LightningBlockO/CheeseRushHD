using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointDisable : MonoBehaviour
{
    public GameObject checkpoint1;
    public GameObject checkpoint2;
    public GameObject checkpoint3;
    public GameObject checkpointthis;
    private void OnTriggerEnter(Collider other)
    {
        checkpoint1.SetActive(false);
        checkpoint2.SetActive(false);
        checkpoint3.SetActive(false);
        checkpointthis.SetActive(true);
    }
}
