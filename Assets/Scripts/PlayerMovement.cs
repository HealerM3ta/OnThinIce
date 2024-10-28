using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;        // Speed of movement
    public float runSpeed;         // Speed of movement while running
    public float jumpForce;        // Force applied when jumping
    public LayerMask groundLayer;  // Layer representing the ground
    public Transform groundCheck;   // Empty object used to check if player is grounded
    public float groundCheckRadius = 0.2f; // Radius of the ground check circle

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded = false;
    private Animator animator;  // Reference to the Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        animator = GetComponent<Animator>();  // Get the Animator component
    }

    void Update()
    {
        // Capture input from the player for horizontal movement
        movement.x = Input.GetAxisRaw("Horizontal");

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump input: W key or Up Arrow key, only if the player is grounded
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) || Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);  // Set jumping animation
        }

        // Check if player is moving or idle
        if (movement.x != 0)
        {
            bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            animator.SetBool("isRunning", isRunning);
            animator.SetBool("isWalking", !isRunning); // Set isWalking if not running
            animator.SetBool("isIdle", false); // Player is moving, so not idle
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true); // Set idle if no horizontal movement
        }
    }

    void FixedUpdate()
    {
        // Check if the Shift key is being pressed to run
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? runSpeed : moveSpeed;

        // Apply horizontal movement to the player's Rigidbody2D
        rb.velocity = new Vector2(movement.x * currentSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jump animation when player lands
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
    }
}

