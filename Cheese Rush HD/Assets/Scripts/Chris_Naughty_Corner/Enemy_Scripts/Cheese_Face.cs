using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cheese_Face : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;

    //start is called before the first frame update 
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    //Update is called once per frame 
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }
}
