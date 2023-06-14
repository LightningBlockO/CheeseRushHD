using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Movement Edit
    public float normalSpeed = 5.0f;
    public float boostedSpeed = 10.0f;
    public float boostDelay = 5.0f;
    private float boostTimer = 0.0f;
    public float jumpForce = 5.0f;
    public float mouseSensitivity = 100.0f;
    public float dashDistance = 10.0f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 2.0f;
    //Camera Edit
    public float normalFOV = 60.0f;
    public float boostedFOV = 90.0f;
    public float FOVTransitionTime = 1.0f;

    //No touch
    private bool isBoosting = false;
    private float playerSpeed;
    private float verticalRotation = 0.0f;
    private Rigidbody rb;
    private bool isDashing = false;
    private bool canDash = true;
    // Camera 
    private Camera playerCamera;
    private float initialFOV;
    private float targetFOV;
    private float fovTransitionTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;
        playerSpeed = normalSpeed;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        verticalRotation = transform.localEulerAngles.x;
        initialFOV = playerCamera.fieldOfView;
        targetFOV = initialFOV;
        fovTransitionTimer = 0.0f;
        isDashing=false;

    }

    void Update()
    {
        // Movement
        float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        transform.Translate(horizontalMovement, 0, verticalMovement);

        // Camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Dash
        if (Input.GetMouseButtonDown(0) && canDash)
        {
            Vector3 dashDirection = transform.forward;
            StartCoroutine(Dash(dashDirection, dashDistance, dashDuration));
            StartCoroutine(DashCooldown());
        }

        // Boost
        if (Input.GetKey(KeyCode.W))
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= boostDelay && !isBoosting)
            {
                isBoosting = true;
                SetPlayerSpeed(boostedSpeed);
                TransitionFOV(normalFOV, boostedFOV);
            }
        }
        else
        {
            // Reset Boost
            boostTimer = 0.0f;

            if (isBoosting)
            {
                isBoosting = false;
                SetPlayerSpeed(normalSpeed);
                TransitionFOV(boostedFOV, normalFOV);
            }
        }

        // FOV
        if (fovTransitionTimer < FOVTransitionTime)
        {
            fovTransitionTimer += Time.deltaTime;
            float t = Mathf.Clamp01(fovTransitionTimer / FOVTransitionTime);
            float newFOV = Mathf.Lerp(initialFOV, targetFOV, t);
            playerCamera.fieldOfView = newFOV;
        }
    }

    private void SetPlayerSpeed(float speed)
    {
        playerSpeed = speed;
    }

    private void TransitionFOV(float startFOV, float endFOV)
    {
        initialFOV = startFOV;
        targetFOV = endFOV;
        fovTransitionTimer = 0.0f;
    }
    private System.Collections.IEnumerator Dash(Vector3 direction, float distance, float duration)
    {
        isDashing = true;
        canDash = false;
        float elapsedTime = 0.0f;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition + direction * distance;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isDashing = false;
    }

    private System.Collections.IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
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


