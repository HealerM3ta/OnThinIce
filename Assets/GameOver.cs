using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over UI Panel
    public Text gameOverText; // Reference to the Game Over text UI

    private void Start()
    {
        gameOverPanel.SetActive(false); // Hide Game Over panel at start
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true); // Show the Game Over panel
        gameOverText.text = "Game Over!"; // Update the Game Over text
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Reset time scale before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
        #endif
    }
}
