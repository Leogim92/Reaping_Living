using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour
{
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
    }
    public void UpgradeGoodKarmaBonus()
    {
        playerStats.GoodKarmaBonus += 10;
        nextLevelButton.SetActive(true);
        buttonRandomizer.DisableUpgradeButtons();
    }
    public void UpgradeBadKarmaBonus()
    {
        playerStats.BadKarmaBonus += 10;
        nextLevelButton.SetActive(true);
        buttonRandomizer.DisableUpgradeButtons();
    }
    public void UpgradeNavMeshSpeed()
    {
        playerStats.NavMeshSpeed += 2;
        nextLevelButton.SetActive(true);
        buttonRandomizer.DisableUpgradeButtons();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
