using UnityEngine;

public class FoodCollection : MonoBehaviour
{
    public FoodManager foodManager;  // Reference to the FoodManager
    public float foodAmountToAdd = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Food collected!");
            foodManager.AddFood(foodAmountToAdd);  // Add food using FoodManager
            Destroy(gameObject);  // Destroy the food object
        }
    }
}
