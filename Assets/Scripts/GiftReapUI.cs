using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GiftReapUI : MonoBehaviour
{
    PersonData _personData;
    PlayerStats _playerStats;

    [SerializeField] Canvas reapGiftCanvas = null;

    [SerializeField] TextMeshProUGUI nameText = null;
    [SerializeField] TextMeshProUGUI ageText = null;
    [SerializeField] TextMeshProUGUI storyText = null;
    [SerializeField] TextMeshProUGUI lifeExpectancyText = null;
    [SerializeField] TextMeshProUGUI eventYearText = null;
    [SerializeField] TextMeshProUGUI eventTypeText = null;
    [SerializeField] TextMeshProUGUI eventDescriptionText = null;


    [SerializeField] Button giftYearsButton = null;
    [SerializeField] Button reapYearsButton = null;
    [SerializeField] Button sealFateButton = null;

    const int SHIFT_VALUE = 5;
    //UI Filling
    public void TriggerReapGiftUI(bool value)
    {
        reapGiftCanvas.enabled = value;
        if (_personData != null) SettingUIButtonsState(_personData.IsFateSealed);
    }

    private void SettingUIButtonsState(bool fateSealState)
    {
        if (!fateSealState)
        {
            giftYearsButton.interactable = true;
            reapYearsButton.interactable = true;
            sealFateButton.interactable = true;
        }
        else
        {
            giftYearsButton.interactable = false;
            reapYearsButton.interactable = false;
            sealFateButton.interactable = false;
        }
    }

    public void PassReaperAndPersonData(PersonData personData, PlayerStats playerStats)
    {
        _personData = personData;
        _playerStats = playerStats;
        SetPersonData();
    }
    public void SetPersonData()
    {
        nameText.text = _personData.Person.Name;
        ageText.text = _personData.Person.Age.ToString();
        storyText.text = _personData.Person.Story;
        lifeExpectancyText.text = _personData.Person.LifeExpectancy.ToString();
        eventYearText.text = _personData.Person.EventYear.ToString();
        if (_personData.Person.karmaEvent) SetKarmaDetails();
    }

    private void SetKarmaDetails()
    {
        eventTypeText.text = UpperFirst(_personData.Person.karmaEvent.karmaAlignment.ToString());
        eventDescriptionText.text = _personData.Person.karmaEvent.eventDescription;
    }

    //Buttons
    public void GiftYears()
    {
        if (_playerStats.YearsCurrency > 0 && _personData.Person.LifeExpectancy < _playerStats.TotalYears)
        {
            int yearsToGift = _playerStats.KarmaYearModifier;

            if (Input.GetKey(KeyCode.LeftShift)
                && _personData.Person.LifeExpectancy <= _playerStats.TotalYears - _playerStats.KarmaYearModifier * SHIFT_VALUE
                && _playerStats.YearsCurrency >= _playerStats.KarmaYearModifier * SHIFT_VALUE)
            {
                yearsToGift = _playerStats.KarmaYearModifier * SHIFT_VALUE;
            }
            else
                yearsToGift = _playerStats.KarmaYearModifier;

            UpdateYears(yearsToGift);
        }
    }
    public void ReapYears()
    {
        if (_playerStats.YearsCurrency < _playerStats.TotalYears && _personData.Person.LifeExpectancy > _personData.Person.Age)
        {
            int yearsToReap = _playerStats.KarmaYearModifier;
            if (Input.GetKey(KeyCode.LeftShift) &&
                _personData.Person.LifeExpectancy > _personData.Person.Age + _playerStats.KarmaYearModifier * SHIFT_VALUE
                && _playerStats.YearsCurrency <= _playerStats.TotalYears - _playerStats.KarmaYearModifier * SHIFT_VALUE)
            {
                yearsToReap = _playerStats.KarmaYearModifier * SHIFT_VALUE;
            }
            else
                yearsToReap = _playerStats.KarmaYearModifier;

            UpdateYears(-yearsToReap);
        }
    }
    private void UpdateYears(int yearValue)
    {
        _personData.Person.LifeExpectancy += yearValue;
        lifeExpectancyText.text = _personData.Person.LifeExpectancy.ToString();
        _playerStats.YearsCurrency += -yearValue;
        _playerStats.Karma +=yearValue;
    }
    public void SealFate()
    {
        _personData.IsFateSealed = true;
        SettingUIButtonsState(true);
        if (_personData.Person.karmaEvent) CalculateKarma();
    }

    void CalculateKarma()
    {
        if(_personData.Person.LifeExpectancy >= _personData.Person.EventYear)
        {
            KarmaModifier(_playerStats.KarmaEventOn);
        }
        else
        {
            KarmaModifier(-_playerStats.KarmaEventOff);
        }
    }

    private void KarmaModifier(int karmaPoints)
    {
        switch (_personData.Person.karmaEvent.karmaAlignment)
        {
            case KarmaEvent.Karma.good:
                _playerStats.Karma += karmaPoints;
                break;
            case KarmaEvent.Karma.bad:
                _playerStats.Karma += -karmaPoints;
                break;
        }
    }

    private string UpperFirst(string text)
    {
        return char.ToUpper(text[0]) +
            ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty);
    }
}
