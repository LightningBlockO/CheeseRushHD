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
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    //Camera Edit
    public float normalFOV = 60.0f;
    public float boostedFOV = 90.0f;
    public float FOVTransitionTime = 1.0f;
    public float maxLookAngle = 0f;

    //No touch
    private bool isBoosting = false;
    private float playerSpeed;
    private float verticalRotation = 0.0f;
    private Rigidbody rb;
    private bool isDashing = false;
    private bool canDash = true;
    private float pitch = 0.0f;
    private bool isGrounded = false;
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
        CheckGround();
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

        // Restriction 
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        // Jump
        if (Input.GetKey(KeyCode.Space) && !isDashing && isGrounded)
        {
            Jump();
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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

    private void FixedUpdate()
    {
        ApplyFallMultiplier();
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }
        
    }

    private void ApplyFallMultiplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
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
    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = .75f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
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


