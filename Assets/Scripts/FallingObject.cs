using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private GameOverScript gameOverScript;

    public void Initialize(GameOverScript gameOverScript)
    {
        this.gameOverScript = gameOverScript; // Set the GameOverScript reference
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Log the object that collided

        // Check if the object collided with the player
        if (collision.gameObject.CompareTag("Player")) // Check if the player was hit
        {
            Debug.Log("Player hit! Game over triggered.");
            gameOverScript.GameOver(); // Call the GameOver function
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
