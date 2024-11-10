using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements
using TMPro; // Import the TextMeshPro namespace

public class Goal : MonoBehaviour
{
    public GameObject uiPanel; // A UI panel to display the message
    public TMP_Text messageText; // TextMeshPro component to show the message

    void Start()
    {
        // Ensure the UI is hidden at the start
        uiPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the player collided with the goal
        {
            PauseGame(); // Pause the game
            ShowMessage("You Survived!"); // Show the message
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
    }

    void ShowMessage(string message)
    {
        messageText.text = message; // Set the message text
        uiPanel.SetActive(true); // Show the UI panel
    }
}
