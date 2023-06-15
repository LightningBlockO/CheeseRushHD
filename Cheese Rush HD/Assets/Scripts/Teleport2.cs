using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerExit(Collider other)
    {
        player.transform.position = new Vector3(435, 27, 2);
    }
}
