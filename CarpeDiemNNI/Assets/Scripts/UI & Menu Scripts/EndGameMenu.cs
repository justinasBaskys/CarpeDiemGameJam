using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public static bool isGameOver = false;
    public GameObject GameOverMenuUI;
    public void Restart ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameLoop");
    }
    public void EndGamePause ()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
