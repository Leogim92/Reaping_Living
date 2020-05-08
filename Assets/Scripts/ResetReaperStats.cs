using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetReaperStats : MonoBehaviour
{
    PlayerStats playerStats;
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerStats.ResetReaperStats();
    }
}
