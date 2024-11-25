using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    public LayerMask wallLayer;  // Add wall layer
    public Transform groundCheck;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public float groundCheckRadius;
    public float wallCheckRadius; // Distance for checking walls

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded = false;
    private bool isTouchingWall = false;
    private bool isClimbing = false;
    private Animator animator;

    public AudioClip runSound;
    public AudioClip jumpSound;

    private AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();  // Get the AudioManager
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Check if the player is touching a wall
        isTouchingWall = Physics2D.OverlapCircle(wallCheckLeft.position, wallCheckRadius, wallLayer) || 
                         Physics2D.OverlapCircle(wallCheckRight.position, wallCheckRadius, wallLayer);

        // Debug to check if player is touching a wall
        Debug.Log("Is touching wall: " + isTouchingWall);

        // Handle jump
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            audioManager.PlaySound(jumpSound);  // Call PlaySound for jump
        }

        // Handle climbing if touching a wall
        if (isTouchingWall && isClimbing)
        {
            rb.gravityScale = 0; // Disable gravity when climbing
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Handle climbing up or down
            if (verticalInput != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, verticalInput * moveSpeed);  // Move up/down
                animator.SetBool("isClimbing", true);

                // Debug to check climbing state
                Debug.Log(verticalInput > 0 ? "Climbing up" : "Climbing down");
            }
            else
            {
                animator.SetBool("isClimbing", false);
            }
        }
        else
        {
            // Restore gravity when not climbing
            rb.gravityScale = 1;
            animator.SetBool("isClimbing", false);
            Debug.Log("Not climbing, restoring gravity");
        }

        // Handle wall movement
        if (isTouchingWall && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            isClimbing = true;
            Debug.Log("Touching right wall, climbing: " + isClimbing);
        }
        else if (isTouchingWall && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            isClimbing = true;
            Debug.Log("Touching left wall, climbing: " + isClimbing);
        }
        else
        {
            isClimbing = false;
            Debug.Log("Not touching wall, climbing: " + isClimbing);
        }

        // Set walking and running animations
        if (movement.x != 0 && !isClimbing)
        {
            bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            animator.SetBool("isRunning", isRunning);
            animator.SetBool("isWalking", !isRunning);

            if (isRunning)
            {
                audioManager.PlayLoop(runSound); // Play looped running sound
            }
            else
            {
                audioManager.StopLoop(); // Stop looped sound if walking
            }
        }
        else if (!isClimbing)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            audioManager.StopLoop(); // Stop sound if player is idle
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? runSpeed : moveSpeed;

        if (!isClimbing)
        {
            rb.velocity = new Vector2(movement.x * currentSpeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
    }
}
