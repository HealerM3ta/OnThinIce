using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public Text gameOverText; 

    private void Start()
    {
        gameOverPanel.SetActive(false); //initially hide game over
    }

    public void GameOver() // Pause the game when player loses, display game over panel
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over!";
        Time.timeScale = 0; 
    }

    public void RestartGame() //if player clicks restart, restart
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void QuitGame() //if player clicks quit, quit
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif
    }
}
