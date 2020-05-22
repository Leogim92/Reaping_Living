﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenusManager : MonoBehaviour
{
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
        playerStats.IsSoundOn = !audioListener.enabled;
        audioListener.enabled = !audioListener.enabled;
    }
    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
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
    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        NextLevelTrigger.OnKarmaGoalFailed -= GameOver;
    }

}
