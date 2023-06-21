using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    #region Movement Variables
    //Movement Edit
    [Header("Movement")]
    public float normalSpeed = 5.0f;
    public float boostedSpeed = 10.0f;
    public float maxBoostedSpeed = 15.0f;
    public float boostDelay = 0.0f;
    public float maxBoostDelay = 0.0f;
    private float boostTimer = 0.0f;
    private float maxBoostTimer = 0.0f;
    public float mouseSensitivity = 100.0f;
    public float maxVelocityChange = 10f;
    #endregion
    #region Dash
    //Dash
    [Header("Dash")]
    public float dashDistance = 10.0f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 2.0f;
    public LayerMask obstacleLayer;
    public bool IsDashing { get; private set; }
    #endregion
    #region Jump
    //Jump
    [Header("Jump")]
    public float jumpForce = 5.0f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    #endregion
    #region AirControl

    //Air control
    private bool isFalling = false;
    private float airTimer = 0f;
    private float maxAirTime = 0.2f;
    #endregion
    #region Camera
    //Camera Edit
    [Header("Camer-FOV")]
    public float normalFOV = 60.0f;
    public float boostedFOV = 90.0f;
    public float maxFOV = 120.0f;
    public float FOVTransitionTime = 1.0f;
    public float maxLookAngle = 0f;
    #endregion
    #region Dont Touch
    //No touch
    private bool isBoosting = false;
    private bool isMaxBoosting = false;
    private float playerSpeed;
    private float verticalRotation = 0.0f;
    private Rigidbody rb;
    private bool isDashing = false;
    private bool isJumping = false;
    private bool canDash = true;
    private float pitch = 0.0f;
    private bool isGrounded = false;

    // Camera 
    private Camera playerCamera;
    private float initialFOV;
    private float targetFOV;
    private float fovTransitionTimer;

    #endregion


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
        isDashing = false;
        isJumping = false;

    }
    private void FixedUpdate()
    {
        ApplyFallMultiplier();
    }

    void Update()
    {
        #region Movement
        CheckGround();
        // Movement

        //float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        //float verticalMovement = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        //transform.Translate(horizontalMovement, 0, verticalMovement);

        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Project onto the horizontal plane (omit vertical component)
        cameraForward.Normalize(); // Normalize the vector to ensure consistent speed

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0; // Project onto the horizontal plane (omit vertical component)
        cameraRight.Normalize();

        Vector3 targetVelocity = (cameraForward * Input.GetAxis("Vertical") + cameraRight * Input.GetAxis("Horizontal")) * playerSpeed;
        Vector3 currentVelocity = rb.velocity;
        Vector3 velocityChange = Vector3.ClampMagnitude(targetVelocity - currentVelocity, maxVelocityChange);
        velocityChange.y = 0;

        float smoothFactor = 0.5f; // Adjust this value for desired smoothness

        rb.velocity = Vector3.Lerp(currentVelocity, currentVelocity + velocityChange, smoothFactor);




        //float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        //float verticalMovement = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        //transform.Translate(horizontalMovement, 0, verticalMovement);

        //Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Vector3 velocity = rb.velocity;
        //Vector3 velocityChange = (targetVelocity - velocity);
        //velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        //velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        //velocityChange.y = 0;

        //rb.AddForce(velocityChange, ForceMode.VelocityChange);
        #endregion
        #region Camera

        // Camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxLookAngle, maxLookAngle);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        

        // Restriction 
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);
        #endregion
        #region Jump


        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && isGrounded)
        {
            Jump();

            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //Air Control
        if (!isGrounded && !isDashing && isJumping)
        {
            airTimer += Time.deltaTime;

            if (airTimer >= maxAirTime)
            {
                FallToGround();
                //Debug.Log("Fall");
            }
        }
        else
        {
            airTimer = 0f;
        }

        // Dash
        if (Input.GetMouseButtonDown(0) && canDash)
        {
            Vector3 dashDirection = transform.forward;
            StartCoroutine(Dash(dashDirection, dashDistance, dashDuration));
            StartCoroutine(DashCooldown());
        }
        #endregion
        #region Boost
        // Boost
        if (Input.GetKeyDown(KeyCode.LeftShift) /*&& Input.GetKey(KeyCode.W)*/)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= boostDelay && !isBoosting)
            {
                isBoosting = true;
                SetPlayerSpeed(boostedSpeed);
                TransitionFOV(normalFOV, normalFOV);
                Debug.Log("Moch1");

            }

            else
            {
                // Reset Boost
                boostTimer = 0.0f;

                if (isBoosting)
                {
                    isBoosting = false;
                    SetPlayerSpeed(normalSpeed);
                    TransitionFOV(normalFOV, normalFOV);
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            maxBoostTimer += Time.deltaTime;
            if (maxBoostTimer >= maxBoostDelay && !isMaxBoosting)
            {
                isMaxBoosting = true;
                SetPlayerSpeed(maxBoostedSpeed);
                TransitionFOV(normalFOV, boostedFOV);
                Debug.Log("Mock2");
            }
        }
        else
        {
            // Reset Boost
            maxBoostTimer = 0.0f;

            if (isMaxBoosting)
            {
                isMaxBoosting = false;
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
    #endregion

    private void FallToGround()
    {
        Vector3 desiredPosition = transform.position - Vector3.up * Time.deltaTime;
        rb.MovePosition(desiredPosition);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            isJumping = true;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce * 0f, ForceMode.Impulse);
            isGrounded = false;
        }
        //if (!isGrounded && !isDashing && !isJumping)
        //{
        //    airTimer += Time.deltaTime;

        //    if (airTimer >= maxAirTime)
        //    {
        //        FallToGround();
        //    }
        //}
        //else
        //{
        //    airTimer = 0f;
        //}
        //float jumpHeight = transform.position.y + jumpForce;

        //if (jumpHeight > maxJumpHeight)
        //{
        //    jumpHeight = maxJumpHeight;
        //}

        //rb.velocity = new Vector3(rb.velocity.x, jumpHeight - transform.position.y, rb.velocity.z);
        //isGrounded = false;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("bababababa");
            Vector3 desiredPosition = rb.position - collision.relativeVelocity * Time.fixedDeltaTime;

            rb.MovePosition(desiredPosition);
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
    //private System.Collections.IEnumerator Dash(Vector3 direction, float distance, float duration)
    //{
    //    isDashing = true;
    //    canDash = false;
    //    float elapsedTime = 0.0f;
    //    Vector3 initialPosition = transform.position;
    //    Vector3 targetPosition = initialPosition + direction * distance;

    //    while (elapsedTime < duration)
    //    {
    //        float t = elapsedTime / duration;
    //        transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    transform.position = targetPosition;
    //    isDashing = false;
    //}
    private IEnumerator Dash(Vector3 direction, float distance, float duration)
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
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, distance, obstacleLayer))
            {
                targetPosition = hit.point;
                break;
            }
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
    //Groudn Check
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