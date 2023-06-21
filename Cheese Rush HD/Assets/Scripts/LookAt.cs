using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LookAt : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Lose Over");
        }
    }
}
