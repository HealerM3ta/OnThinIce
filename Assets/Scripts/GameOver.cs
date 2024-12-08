using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public TextMeshProUGUI gameOverText; 
    public GameObject startMenu;  // Reference to the Start screen UI
    
    private void Start()
    {
        // Hide the Game Over panel initially
        gameOverPanel.SetActive(false);

    }

    public void GameOver() // Pause the game when player loses, display Game Over panel
    {
        Debug.Log("Game Over called!");
        gameOverPanel.SetActive(true); // Show the Game Over panel
        gameOverText.text = "Game Over!";
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame() // If the player clicks restart
    {
        Time.timeScale = 1; // Make sure the time scale is set to 1 when restarting
        gameOverPanel.SetActive(false); // Hide the Game Over panel
        // Reload the scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() // If player clicks quit, quit the game
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif
    }
}
