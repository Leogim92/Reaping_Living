using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudUI : MonoBehaviour
{
    PointManager playerPoints;

    [SerializeField] TextMeshProUGUI yearCurrencyText = null;
    [SerializeField] TextMeshProUGUI karmaText = null;
    private void Awake()
    {
        playerPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PointManager>();
    }
    void Update()
    {
        yearCurrencyText.text = playerPoints.YearsCurrency.ToString();
        karmaText.text = playerPoints.Karma.ToString();
    }
}
