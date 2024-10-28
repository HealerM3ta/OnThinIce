using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    // Reference to the GameOverScript
    private GameOverScript gameOverScript;

    private void Start()
    {
        // Find the GameOverScript attached to the GameObject in the scene
        gameOverScript = FindObjectOfType<GameOverScript>();
        
        if (gameOverScript == null)
        {
            Debug.LogError("GameOverScript not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the death zone
        if (other.CompareTag("Player"))
        {
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player has entered a death zone!");

        // Trigger game over
        if (gameOverScript != null)
        {
            gameOverScript.GameOver();
        }
    }
}