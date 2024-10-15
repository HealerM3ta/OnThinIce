using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Speed of movement
    public float runSpeed = 10f;         // Speed of movement while running
    public float jumpForce = 9f;        // Force applied when jumping
    public LayerMask groundLayer;        // Layer representing the ground
    public Transform groundCheck;        // Empty object used to check if player is grounded
    public float groundCheckRadius = 0.2f; // Radius of the ground check circle

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
    }

    void Update()
    {
        // Capture input from the player for horizontal movement
        movement.x = Input.GetAxisRaw("Horizontal");

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump input: W key or Up Arrow key, only if the player is grounded
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Check if the Shift key is being pressed to run
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? runSpeed : moveSpeed;

        // Apply horizontal movement to the player's Rigidbody2D
        rb.velocity = new Vector2(movement.x * currentSpeed, rb.velocity.y);
    }
}
