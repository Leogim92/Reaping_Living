using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour
{
    public static event Action OnUITrigger;

    [SerializeField] GameObject nextLevelButton = null;
    PlayerStats playerStats;
    ButtonRandomizer buttonRandomizer;
    private void Awake()
    {
        Cursor.SetCursor(default, Vector2.zero, CursorMode.Auto);
        playerStats = FindObjectOfType<PlayerStats>();
        buttonRandomizer = GetComponent<ButtonRandomizer>();
    }
    public void UpgradeTotalYears()
    {
        playerStats.TotalYears += 25;
        nextLevelButton.SetActive(true);
        buttonRandomizer.DisableUpgradeButtons();
        OnUITrigger?.Invoke();
    }
    public void UpgradeGoodKarmaBonus()
    {
        playerStats.GoodKarmaBonus += 10;
        nextLevelButton.SetActive(true);
        buttonRandomizer.DisableUpgradeButtons();
        OnUITrigger?.Invoke();
    }
    public void UpgradeBadKarmaBonus()
    {
        playerStats.BadKarmaBonus += 10;
        nextLevelButton.SetActive(true);
        buttonRandomizer.DisableUpgradeButtons();
        OnUITrigger?.Invoke();
    }
    public void UpgradeNavMeshSpeed()
    {
        playerStats.NavMeshSpeed += 2;
        nextLevelButton.SetActive(true);
        buttonRandomizer.DisableUpgradeButtons();
        OnUITrigger?.Invoke();
    }

    public void LoadNextScene()
    {
        OnUITrigger?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
