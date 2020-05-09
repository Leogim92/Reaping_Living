using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HudUI : MonoBehaviour
{
    PlayerStats playerStats;
    PersonData [] peopleInScene;

    [SerializeField] TextMeshProUGUI yearCurrencyText = null;
    [SerializeField] TextMeshProUGUI karmaText = null;
    [SerializeField] TextMeshProUGUI fatesToSealText = null;
    

    [Space]
    [SerializeField] TextMeshProUGUI karmaGoal = null;
    [SerializeField] TextMeshProUGUI goodEventsText = null;
    [SerializeField] TextMeshProUGUI badEventsText = null;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        peopleInScene = FindObjectsOfType<PersonData>();
    }
    private void Start()
    {
        Invoke("StartUI",.1f);
        GiftReapUI.OnGiftReap += UIGiftReapUpdate;
        GiftReapUI.OnFateSeal += UISealFate;
    }

    private void StartUI()
    {
        UIGiftReapUpdate();
        UISealFate();
        
        karmaGoal.text = "Karma Goal: " + playerStats.KarmaGoal;
    }

    void UIGiftReapUpdate()
    {
        yearCurrencyText.text = playerStats.YearsCurrency.ToString();
        karmaText.text = playerStats.Karma.ToString();
    }
    void UISealFate()
    {
        UpdateFateToSeal();
        goodEventsText.text = "Good Events Done: " + playerStats.GoodEventsDone;
        badEventsText.text = "Bad Events Avoided: " + playerStats.BadEventsAvoided;
        karmaText.text = playerStats.Karma.ToString();
    }

    private void UpdateFateToSeal()
    {
        int fatesToSeal = 0;
        foreach (PersonData person in peopleInScene)
        {
            if (!person.IsFateSealed) fatesToSeal++;
        }
        fatesToSealText.text = "Fates to Seal: " + fatesToSeal;
    }
    
    private void OnDestroy()
    {
        GiftReapUI.OnGiftReap -= UIGiftReapUpdate;
        GiftReapUI.OnFateSeal -= UISealFate;
    }
}
