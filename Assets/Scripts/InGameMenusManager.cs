using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenusManager : MonoBehaviour
{
    public static event Action<bool> OnSoundTrigger;
    public static event Action OnUITrigger;

    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] GameObject gameOverMenu = null;
    [SerializeField] TextMeshProUGUI karmaScore = null;
    AudioListener audioListener;
    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        audioListener = FindObjectOfType<AudioListener>();
    }
    private void Start()
    {
        audioListener.enabled = playerStats.IsSoundOn;
        NextLevelTrigger.OnKarmaGoalFailed += GameOver;
    }
    private void GameOver()
    {
        Time.timeScale = 0;
        karmaScore.text = "Karma Score: " + playerStats.Karma + "/" + playerStats.KarmaGoal;
        gameOverMenu.SetActive(true);
        
    }

    public void EnableDisableSound()
    {
        playerStats.IsSoundOn = !playerStats.IsSoundOn;
        OnSoundTrigger?.Invoke(playerStats.IsSoundOn);
        OnUITrigger?.Invoke();

    }
    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        OnUITrigger?.Invoke();
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        OnUITrigger?.Invoke();
    }
    public void ReturnToMainMenu()
    {
        OnUITrigger?.Invoke();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void TakeTutorial()
    {
        OnUITrigger?.Invoke();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        OnUITrigger?.Invoke();
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        OnUITrigger?.Invoke();
        Application.Quit();
    }

    private void OnDestroy()
    {
        NextLevelTrigger.OnKarmaGoalFailed -= GameOver;
    }

}
