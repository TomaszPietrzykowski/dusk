using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement controls")]
    public float walkingSpeed = 100f; // normal speed: 100
    public float sprintingSpeed = 180f; // default: 180

    [Header("Slowing factors")]
    public float slowdown = 0f; // designed to be used in 0 - 100 scope

    [Header("Jump controls")]
    public float gravity = -20f;
    public float jumpHeight = 1.22f;
    Vector3 velocity;

    [Header("Grounded control")]
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    bool isGrounded;
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        float x  = Input.GetAxis("Horizontal");
        float z  = Input.GetAxis("Vertical");

        // Absolute movement N-S-E-W, unrelated to mouse/view:
        // Use case: boat eg.
        // Vector3 move = new Vector3(x, 0f, z);

        // Move in relation to camera vector:
        Vector3 move = transform.right * x + transform.forward * z;

        float speed = walkingSpeed;

        // Run
        if(isGrounded && Input.GetKey("left shift"))
        {
            speed =  sprintingSpeed;
        }

        // Tested and factored in speed vs tiredness formula:
        controller.Move(move * (speed * 3 / (100 + slowdown * 2)) * Time.deltaTime);

        // apply gravity force
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Jump:
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
