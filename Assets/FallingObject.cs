using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private GameOverScript gameOverScript;

    private void Start()
    {
        gameOverScript = GameObject.FindObjectOfType<GameOverScript>(); // Find GameOverScript
        if (gameOverScript == null)
        {
            Debug.LogError("GameOverScript not found in the scene!"); // Check if GameOverScript is correctly attached
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Log the object that collided

        if (collision.gameObject.CompareTag("Player")) // Check if the player was hit
        {
            Debug.Log("Player hit! Game over triggered.");
            gameOverScript.GameOver(); // Call the GameOver function
            Destroy(gameObject); // Destroy the falling object
        }
    }
}
