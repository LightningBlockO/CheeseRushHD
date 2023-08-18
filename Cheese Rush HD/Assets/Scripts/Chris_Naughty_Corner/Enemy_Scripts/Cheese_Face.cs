using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cheese_Face : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;
    public GameObject cheeseFace;

    private bool isFrozen = true; 

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Invoke("Unfreeze", 6f); 
    }

    // Update is called once per frame 
    void Update()
    {
        if (!isFrozen)
        {
            FollowTarget();
        }
    }

    public void Unfreeze()
    {
        isFrozen = false; 
    }

    public void FollowTarget()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }
}
