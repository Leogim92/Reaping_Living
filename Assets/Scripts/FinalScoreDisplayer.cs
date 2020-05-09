using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goodEventsText =null;
    [SerializeField] TextMeshProUGUI badEventsText = null;
    [SerializeField] TextMeshProUGUI karmaPointsText = null;

    PlayerStats playerStats;

    private void Awake()
    {
        Cursor.SetCursor(default, Vector2.zero, CursorMode.Auto);
        playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Start()
    {
        goodEventsText.text = "Good Events: " + playerStats.GoodEventsDone;
        badEventsText.text = "Bad Events: " + playerStats.BadEventsAvoided;
        karmaPointsText.text = "Karma Points: " + playerStats.Karma;
    }
}
