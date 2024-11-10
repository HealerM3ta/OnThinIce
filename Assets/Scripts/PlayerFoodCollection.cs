using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollection : MonoBehaviour
{
    public Health playerHealth;  // Reference to the player's Health script
    public FoodCollectionUI foodUI;  // Reference to the Food Collection UI

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with the food
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Food collected by player!");

            // Add food to the UI
            //foodUI.AddFood();

            // Add 1 health to the player when food is collected
            playerHealth.health += 1;

            // Destroy the food object after collection
            Destroy(gameObject);
        }
    }
}
