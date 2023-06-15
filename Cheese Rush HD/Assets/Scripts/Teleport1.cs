using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerExit(Collider other)
    {
        player.transform.position = new Vector3(294, 10, -414);
    }
}
