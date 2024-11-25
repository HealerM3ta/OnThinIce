using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    public Health playerHealth;  // Reference to the player's health script
    public Slider foodSlider;    // Reference to the slider for the food bar
    public float food;           // Current food amount
    public float maxFood = 100f; // Maximum food amount
    public float foodDecreaseRate = 1f; // Rate at which food decreases
    private float timeAtZeroFood;  // Timer for food at zero
    private bool isFoodZero = false; // Flag for food at zero

    void Start()
    {
        // Initialize the slider's properties
        foodSlider.maxValue = maxFood;
        foodSlider.value = food;
    }

    void Update()
    {
        // Decrease food over time
        DecreaseFoodOverTime();

        // Update the slider value
        foodSlider.value = food;

        // Check for food at zero
        if (food <= 0 && !isFoodZero)
        {
            isFoodZero = true;
            timeAtZeroFood = 0f; // Reset timer
        }

        if (isFoodZero)
        {
            timeAtZeroFood += Time.deltaTime;

            if (timeAtZeroFood >= 30f)
            {
                LoseHealth();
                timeAtZeroFood = 0f;
                isFoodZero = false; // Reset flag after losing health
            }
        }

        // Check if food bar is full
        if (food >= maxFood)
        {
            AddHealth();
            food = maxFood; // Prevent food from exceeding max
        }
    }

    void DecreaseFoodOverTime()
    {
        if (food > 0)
        {
            food -= foodDecreaseRate * Time.deltaTime;
        }
        else
        {
            food = 0; // Ensure food doesn't go negative
        }
    }

    public void AddFood(float amount)
    {
        food = Mathf.Min(food + amount, maxFood); // Add food and cap at max
    }

    void LoseHealth()
    {
        if (playerHealth != null)
        {
            playerHealth.health -= 1;
            Debug.Log("Food is at zero for 30 seconds. Health decreased: " + playerHealth.health);
        }
    }

    void AddHealth()
    {
        if (playerHealth != null)
        {
            playerHealth.health += 1; // Increase health by 1
            Debug.Log("Food bar full! Health increased to: " + playerHealth.health);
        }
    }
}
