using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCollectionUI : MonoBehaviour
{
    public Image[] foodIcons;  // Assign the food icon images in the Inspector
    private int foodCollected = 0;  // Track the number of food icons that have been enabled

    // Method to add food (fill one food icon)
    public void AddFood()
    {
        Debug.Log("AddFood called");  // Debug message to confirm the method is being called

        // Only enable food icons if there are still available slots (food icons left)
        if (foodCollected < foodIcons.Length)
        {
            foodIcons[foodCollected].enabled = true;  // Enable the next food icon
            foodCollected++;  // Increment the food collected count
        }
        else
        {
            Debug.Log("Food is full, cannot add more.");
        }
    }

    // Method to reset the food UI (hide all food icons)
    public void ResetFoodUI()
    {
        foreach (Image icon in foodIcons)
        {
            icon.enabled = false;  // Hide all food icons
        }
        foodCollected = 0;  // Reset food counter
    }
}
