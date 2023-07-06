using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_3 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerExit(Collider other)
    {
        player.transform.position = new Vector3(593f, 21.5f, -60.5f);
    }
}
