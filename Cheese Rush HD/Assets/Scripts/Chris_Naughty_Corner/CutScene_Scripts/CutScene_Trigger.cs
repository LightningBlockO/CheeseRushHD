using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene_Trigger : MonoBehaviour
{
    public GameObject player;
    public GameObject CutScene;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        CutScene.SetActive(true);
        player.SetActive(false);
        StartCoroutine(FinishCut());
        Debug.Log("ahahahah");

    }
    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(3f);
        player.SetActive(true);
        CutScene.SetActive(false);
        Debug.Log("fix");
    }
}
