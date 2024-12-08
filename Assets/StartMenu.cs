using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu;  // Reference to the Start Menu UI
    public GameObject instructionsScreen;  // Reference to the Instructions Screen UI

    void Start()
    {
        // Freeze the game on start
        Time.timeScale = 0f; // Pause the game

        // Ensure start menu is active and instructions screen is hidden initially
        startMenu.SetActive(true);
        instructionsScreen.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        Time.timeScale = 1f; // Resume the game
        startMenu.SetActive(false); // Hide the start menu (this Canvas)
        instructionsScreen.SetActive(false); // Hide the instructions screen if it's showing
    }

    public void OnInstructionsButtonClick()
    {
        instructionsScreen.SetActive(true); // Show the instructions screen
    }

    public void OnBackButtonClick()  // Back button in Instructions screen
    {
        instructionsScreen.SetActive(false); // Hide the instructions screen
    }
}
