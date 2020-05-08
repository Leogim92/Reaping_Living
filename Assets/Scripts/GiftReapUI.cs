using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GiftReapUI : MonoBehaviour
{
    PersonData _personData;
    PointManager _playerPoints;

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

    public void PassReaperAndPersonData(PersonData personData, PointManager playerPoints)
    {
        _personData = personData;
        _playerPoints = playerPoints;
        SetPersonData();
    }
    public void SetPersonData()
    {
        nameText.text = _personData.Person.Name;
        ageText.text = _personData.Person.Age.ToString();
        storyText.text = _personData.Person.Story;
        lifeExpectancyText.text = _personData.Person.LifeExpectancy.ToString();
        eventYearText.text = _personData.Person.EventYear.ToString();
        if (_personData.Person.karmaEvent !=null) SetKarmaDetails();
    }

    private void SetKarmaDetails()
    {
        eventTypeText.text = UpperFirst(_personData.Person.karmaEvent.karmaAlignment.ToString());
        eventDescriptionText.text = _personData.Person.karmaEvent.eventDescription;
    }

    //Buttons
    public void GiftYears()
    {
        if (_playerPoints.YearsCurrency > 0 && _personData.Person.LifeExpectancy < 100)
        {
            int yearsToGift = 1;
            if (Input.GetKey(KeyCode.LeftShift) && _personData.Person.LifeExpectancy < 96
                && _playerPoints.YearsCurrency >= 5)
                yearsToGift = 5;
            else
                yearsToGift = 1;

            UpdateYears(yearsToGift);
        }
    }
    public void ReapYears()
    {
        if (_playerPoints.YearsCurrency < 100 && _personData.Person.LifeExpectancy > _personData.Person.Age)
        {
            int yearsToReap = 1;
            if (Input.GetKey(KeyCode.LeftShift) && _personData.Person.LifeExpectancy > _personData.Person.Age + 5
                && _playerPoints.YearsCurrency <= 95)
                yearsToReap = 5;
            else
                yearsToReap = 1;

            UpdateYears(-yearsToReap);
        }
    }
    private void UpdateYears(int yearsToGift)
    {
        _personData.Person.LifeExpectancy += yearsToGift;
        lifeExpectancyText.text = _personData.Person.LifeExpectancy.ToString();
        _playerPoints.UpdateYears(-yearsToGift);
        _playerPoints.UpdateKarma(yearsToGift);
    }
    public void SealFate()
    {
        _personData.IsFateSealed = true;
        SettingUIButtonsState(true);
        CalculateKarma();
    }

    void CalculateKarma()
    {
        if(_personData.Person.LifeExpectancy >= _personData.Person.EventYear)
        {
            KarmaModifier(50);
        }
        else
        {
            KarmaModifier(-25);
        }
    }

    private void KarmaModifier(int karmaPoints)
    {
        switch (_personData.Person.karmaEvent.karmaAlignment)
        {
            case KarmaEvent.Karma.good:
                _playerPoints.UpdateKarma(karmaPoints);
                break;
            case KarmaEvent.Karma.bad:
                _playerPoints.UpdateKarma(-karmaPoints);
                break;
        }
    }

    private string UpperFirst(string text)
    {
        return char.ToUpper(text[0]) +
            ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty);
    }
}
