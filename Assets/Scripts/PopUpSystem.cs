using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    [SerializeField] Animator unsealedFates =null;
    [SerializeField] Animator sealedFates =null;
    [SerializeField] GameObject karmaPlus = null;
    [SerializeField] GameObject karmaMinus = null;

    PersonData[] peopleInScene;
    private void Awake()
    {
        peopleInScene = FindObjectsOfType<PersonData>();
    }
    private void Start()
    {
        NextLevelTrigger.OnUnsealedFates += DisplayUnsealedText;
        GiftReapUI.OnFateSeal += DisplaySealedText;
        GiftReapUI.OnKarmaSealedUpdate += KarmaPointsPopUp;
    }

    void DisplayUnsealedText()
    {
        unsealedFates.SetTrigger("PopUp");
    }
    void DisplaySealedText()
    {
        foreach (PersonData person in peopleInScene)
        {
            if (person.IsFateSealed == false)
            {
                return;
            }
        }
        sealedFates.SetTrigger("PopUp");
    }
    void KarmaPointsPopUp(int karma)
    {
        if (karma > 0)
        {
            karmaPlus.GetComponent<TextMeshProUGUI>().text = "+" + karma + " Karma Points";
            karmaPlus.GetComponent<Animator>().SetTrigger("PopUp");
        }
        else
        {
            karmaMinus.GetComponent<TextMeshProUGUI>().text = karma + " Karma Points";
            karmaMinus.GetComponent<Animator>().SetTrigger("PopUp");
        }
    }
    private void OnDestroy()
    {
        NextLevelTrigger.OnUnsealedFates -= DisplayUnsealedText;
        GiftReapUI.OnFateSeal -= DisplaySealedText;
        GiftReapUI.OnKarmaSealedUpdate -= KarmaPointsPopUp;
    }
}
