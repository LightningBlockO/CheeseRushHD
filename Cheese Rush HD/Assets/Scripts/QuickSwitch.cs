using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSwitch : MonoBehaviour
{
    public GameObject Kitchenmusic;
    public GameObject Newcheeserushmusic;
    private void OnTriggerEnter(Collider other)
    {
        Kitchenmusic.SetActive(false);
        Newcheeserushmusic.SetActive(true);
    }
}
