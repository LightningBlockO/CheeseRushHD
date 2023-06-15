using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerExit(Collider other)
    {
        player.transform.position = new Vector3(0, 4, 0);
    }
}
