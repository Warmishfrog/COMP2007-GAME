using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float runSpeed;
    public float walkSpeed;
    public float horizontalInput; //left, right
    public float verticalInput; //forward, back

    [Header("Jump")]
    public float jumpForce; //jump height
    public float jumpCooldown; //time before jump can be initiated again
    public float airMultiplier; //turn rate in air
    public float fallMultiplier; //increases gravity on fall
    public bool readyToJump;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode SprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float groundDrag;
    public float playerHeight; //about 1
    public LayerMask whatIsGround; //make sure to set terrain as the layer
    public bool grounded;
    public LayerMask Water;
    public bool watered;


    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public Transform orientation;
    public Transform Spawnpoint;
    public AudioSource footsteps_audio;


    public Animator camBob;
    public Animator PlayerAnim;

    Vector3 moveDirection;
    Rigidbody rb;



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        transform.position = Spawnpoint.position;

        readyToJump = true;
    }

    // Update is called once per frame
    private void Update()
    {

        FloorChecker();
        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        if (grounded && (rb.velocity.x > 0.5 || rb.velocity.z > 0.5 || rb.velocity.x < -0.5 || rb.velocity.z < -0.5))
        {
            camBob.SetTrigger("walk");
            PlayerAnim.SetTrigger("walk");

            if (!footsteps_audio.isPlaying) footsteps_audio.Play();
        }
        else
        {
            camBob.SetTrigger("idle");
            PlayerAnim.SetTrigger("idle");
            footsteps_audio.Stop();
        }

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        if (grounded && Input.GetKey(SprintKey))
        {
            moveSpeed = runSpeed;
            PlayerAnim.SetFloat("animMultiplier", 3f);
        }
        else if (!Input.GetKey(SprintKey))
        {
            moveSpeed = walkSpeed;
            PlayerAnim.SetFloat("animMultiplier", 1f);
        }

    }
    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;



        //on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 100f, ForceMode.Force);
        }
        // turn gravity off while on slope
        rb.useGravity = !OnSlope();
    }

    
    private void SpeedControl()
    {
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }
        else //limiting speed when in not on a slope (ground & air)
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

            // limit velocity if needed
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
        //downfall to help make jumps feel better        
        if (rb.velocity.y < 0f)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
        }
    }

    private void Jump()
    {
        exitingSlope = true;
        camBob.SetTrigger("idle");

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }
    
    private void ResetJump()
    {
        readyToJump = true;
        exitingSlope = false;
    }

    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
    private void FloorChecker()
    {
        // ground check
        float groundray = playerHeight + 0.3f;
        grounded = Physics.Raycast(transform.position, Vector3.down, groundray, whatIsGround);
        
        //debug check
        Vector3 down = transform.TransformDirection(Vector3.down) * groundray;
        UnityEngine.Debug.DrawRay(transform.position, down, Color.yellow);
    }
}

