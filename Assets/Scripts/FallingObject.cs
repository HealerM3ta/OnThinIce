using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Health playerHealth; // Reference to the player's Health script

    // Initialize method to set the player's health reference
    public void Initialize(Health playerHealth)
    {
        this.playerHealth = playerHealth; // Set the Health script reference
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Log the object that collided

        // Check if the object collided with the player
        if (collision.gameObject.CompareTag("Player")) // Check if the player was hit
        {
            Debug.Log("Player hit! Reducing health.");
            playerHealth.health -= 1; // Reduce the player's health by 1

            // Optionally, check if health goes below 0 and handle game over
            if (playerHealth.health <= 0)
            {
                playerHealth.health = 0; // Ensure health doesn't go negative
                // Optionally trigger Game Over if health reaches 0
                // gameOverScript.GameOver();
            }

            Destroy(gameObject); // Destroy the falling object
        }
        // Check if the object collided with the ground
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Falling object hit the ground and does nothing.");
            Destroy(gameObject); // Optionally destroy the object if it hits the ground
        }
    }
}
