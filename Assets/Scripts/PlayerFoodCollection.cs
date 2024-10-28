using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodCollection : MonoBehaviour
{
    public FoodCollectionUI foodUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); 
        if (collision.CompareTag("Food"))
        {
            Debug.Log("FoodCollision");
            foodUI.AddFood();  // Add food to the UI
            Destroy(collision.gameObject);  // Remove the collected food from the scene
        }
    }
}
