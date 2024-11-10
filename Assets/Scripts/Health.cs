using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameOverScript gameOverScript; // Reference to the GameOverScript

    void Start()
    {
        // Ensure GameOverScript is assigned properly, either from the inspector or found dynamically
        if (gameOverScript == null)
        {
            gameOverScript = FindObjectOfType<GameOverScript>(); // Dynamically find GameOverScript if not assigned
        }

        if (gameOverScript == null)
        {
            Debug.LogError("GameOverScript not found in the scene! Make sure it's attached to a GameObject.");
            return; // Return to prevent null reference errors
        }

        // Ensure health is clamped between 0 and numOfHearts at the start
        health = Mathf.Clamp(health, 0, numOfHearts);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health > numOfHearts){
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++) {
            if (i < health){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
        // If health reaches zero, trigger the GameOver function
        if (health <= 0) {
            gameOverScript.GameOver(); // Call GameOver from the GameOverScript
        }
    }
}
