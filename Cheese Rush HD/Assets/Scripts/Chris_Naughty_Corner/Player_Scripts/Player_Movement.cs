using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public float mouseSensitivity = 100.0f;

    private float verticalRotation = 0.0f;
    private Rigidbody rb;

    //public AudioSource Walk;
    //private bool isWalking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        verticalRotation = transform.localEulerAngles.x;
    }

    void Update()
    {
        // Movement
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(horizontalMovement, 0, verticalMovement);

        //Camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);


        // jUmp
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("ajdjsad");
        }
    }
}

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    isWalking = true;
        //    Walk.Play();
        //}

        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    isWalking = false;
        //    Walk.Stop();
        //}
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    isWalking = false;
        //    Walk.Stop();
        //}
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    isWalking = false;
        //    Walk.Stop();
        //}
        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    isWalking = false;
        //    Walk.Stop();
        //}
        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    isWalking = false;
        //    Walk.Stop();
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    isWalking = false;
        //    Walk.Stop();
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    isWalking = false;
        //    Walk.Stop();
        //}

    
