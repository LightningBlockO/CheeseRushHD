using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport3 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerExit(Collider other)
    {
        player.transform.position = new Vector3(698, 55, -761);
    }
}
