using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapInteraction : MonoBehaviour
{
    [SerializeField] GiftReapUI giftReapUI = null;
    [SerializeField] Texture2D cursorTexture = null;
    PointManager points;
    private void Awake()
    {
        points = GetComponent<PointManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.transform.GetComponent<PersonData>())
            {
                FireUpReapGiftUI(hit.transform.GetComponent<PersonData>());
            }
        }
    }
    private void FireUpReapGiftUI(PersonData personData)
    {
        PersonData _personData = personData;
        giftReapUI.PassReaperAndPersonData(personData, points);
        giftReapUI.TriggerReapGiftUI(true);
    }
}
