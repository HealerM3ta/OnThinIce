using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCollectionUI : MonoBehaviour
{
    public Image[] foodIcons;  // Assign the food icon images in the Inspector
    private int foodCollected = 0;

public void AddFood()
{
    Debug.Log("AddFood called");  // Debug message to see if the method is being called
    if (foodCollected < foodIcons.Length)
    {
        foodIcons[foodCollected].enabled = true;  // Enable the next food icon
        foodCollected++;
    }
}

    public void ResetFoodUI()
    {
        foreach (Image icon in foodIcons)
        {
            icon.enabled = false;  // Hide all food icons
        }
        foodCollected = 0;
    }
}
