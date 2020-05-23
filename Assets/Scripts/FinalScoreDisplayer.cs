using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        goodEventsText.text = "Good Events Done: " + playerStats.GoodEventsDone;
        badEventsText.text = "Bad Events Avoided: " + playerStats.BadEventsAvoided;
        karmaPointsText.text = "Karma Points: " + playerStats.Karma;
    }
    public void ReturnToMainMeneu()
    {
        SceneManager.LoadScene(0);
    }
}
