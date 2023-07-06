using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_1 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerExit(Collider other)
    {
        player.transform.position = new Vector3(394.5f, 21.5f, -132f);
    }
}
