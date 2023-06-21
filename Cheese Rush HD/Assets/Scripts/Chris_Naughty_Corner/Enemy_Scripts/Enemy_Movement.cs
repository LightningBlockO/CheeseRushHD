using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDistance = 5f;
    private bool isMovingRight = true;
    private Vector3 initialPosition;

    private Player_Movement playerDash;

    private void Start()
    {
        initialPosition = transform.position;
        playerDash = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        
    }

    private void Update()
    {
        if (transform.position.z >= initialPosition.z + moveDistance)
        {
            isMovingRight = false;
        }
        else if (transform.position.z <= initialPosition.z - moveDistance)
        {
            isMovingRight = true;
        }
        if (isMovingRight)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }
     // Reference to the player's dashing script

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerDash.IsDashing)
        {
            Destroy(gameObject); // Destroy the enemy object
        }
    }
}
