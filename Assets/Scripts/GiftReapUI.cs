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
            giftYearsButton.interactable = !fateSealState;
            reapYearsButton.interactable = !fateSealState;
            sealFateButton.interactable = !fateSealState;
        }
        else
        {
            giftYearsButton.interactable = !fateSealState;
            reapYearsButton.interactable = !fateSealState;
            sealFateButton.interactable = !fateSealState;
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
        lifeExpectancyText.text = _personData.LifeExpectancy.ToString();
        eventYearText.text = _personData.Person.EventYear.ToString();
        eventTypeText.text = UpperFirst(_personData.Person.karmaEvent.karmaAlignment.ToString());
        eventDescriptionText.text = _personData.Person.karmaEvent.eventDescription;
    }
    //Buttons

    public void GiftYears()
    {
        RaiseYears();
    }
    public void ReapYears()
    {
        LowYears();
    }
    void RaiseYears()
    {
        if (_playerPoints.YearsCurrency > 0)
        {

            _personData.LifeExpectancy++;
            lifeExpectancyText.text = _personData.LifeExpectancy.ToString();
            _playerPoints.UpdateYears(-1);
            _playerPoints.UpdateKarma(1);
        }
    }
    void LowYears()
    {
        if (_playerPoints.YearsCurrency < 100 && _personData.LifeExpectancy > _personData.Person.Age)
        {
            _personData.LifeExpectancy--;
            lifeExpectancyText.text = _personData.LifeExpectancy.ToString();
            _playerPoints.UpdateYears(1);
            _playerPoints.UpdateKarma(-1);
        }
    }
    public void SealFate()
    {
        _personData.IsFateSealed = true;
        SettingUIButtonsState(true);
        CalculateKarma();
    }

    void CalculateKarma()
    {
        if(_personData.LifeExpectancy >= _personData.Person.EventYear)
        {
            switch (_personData.Person.karmaEvent.karmaAlignment)
            {
                case KarmaEvent.Karma.good:
                    _playerPoints.UpdateKarma(50);
                    break;
                case KarmaEvent.Karma.bad:
                    _playerPoints.UpdateKarma(-50);
                    break;
            }
        }
    }
    private string UpperFirst(string text)
    {
        return char.ToUpper(text[0]) +
            ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty);
    }
}
