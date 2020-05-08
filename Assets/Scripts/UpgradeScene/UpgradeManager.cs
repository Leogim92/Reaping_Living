using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject nextLevelButton = null;
    PlayerStats playerStats;
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
    public void UpgradeTotalYears()
    {
        playerStats.TotalYears += 25;
        nextLevelButton.SetActive(true);
    }
    public void UpgradeGoodKarmaBonus()
    {
        playerStats.GoodKarmaBonus += 10;
        nextLevelButton.SetActive(true);
    }
    public void UpgradeBadKarmaBonus()
    {
        playerStats.BadKarmaBonus += 10;
        nextLevelButton.SetActive(true);
    }
    public void UpgradeNavMeshSpeed()
    {
        playerStats.NavMeshSpeed += 2;
        nextLevelButton.SetActive(true);
    }
    public void UpgradeInteractionRange()
    {
        playerStats.InteractionRange += 4;
        nextLevelButton.SetActive(true);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
