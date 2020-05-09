using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenusManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void TakeTutorial()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
