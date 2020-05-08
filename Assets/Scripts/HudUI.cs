using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudUI : MonoBehaviour
{
    PlayerStats playerStats;

    [SerializeField] TextMeshProUGUI yearCurrencyText = null;
    [SerializeField] TextMeshProUGUI karmaText = null;
    private void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
    void Update()
    {
        yearCurrencyText.text = playerStats.YearsCurrency.ToString();
        karmaText.text = playerStats.Karma.ToString();
    }
}
