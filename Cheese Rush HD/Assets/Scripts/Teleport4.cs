using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport4 : MonoBehaviour
{
    public GameObject player;
    public GameObject lap2music;
    public GameObject cheeserushmusic;
    public GameObject lap2logo;
    public GameObject rushcheeselap1;
    public GameObject rushcheeselap2;
    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = new Vector3(698, 48, -761);
        lap2music.SetActive(true);
        cheeserushmusic.SetActive(false);
        lap2logo.SetActive(true);
        rushcheeselap1.SetActive(false);
        rushcheeselap2.SetActive(true);
    }
}
