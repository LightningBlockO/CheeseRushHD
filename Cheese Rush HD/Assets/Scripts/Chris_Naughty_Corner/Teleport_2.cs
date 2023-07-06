using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_2 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerExit(Collider other)
    {
        player.transform.position = new Vector3(493.5f, 21.5f, -44.5f);
    }
}
