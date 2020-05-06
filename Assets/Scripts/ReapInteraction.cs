using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapInteraction : MonoBehaviour
{
    [SerializeField] GiftReapUI giftReapUI = null;
    PointManager points;
    private void Awake()
    {
        points = GetComponent<PointManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PersonData>())
        {
            PersonData personData = other.GetComponent<PersonData>();
            giftReapUI.PassReaperAndPersonData(personData,points);
            giftReapUI.TriggerReapGiftUI(true);
        }
    }
}
