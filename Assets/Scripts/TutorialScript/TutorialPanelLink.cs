using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanelLink : MonoBehaviour
{
    PanelManager panelManager;

    PersonData person;
    DoorTransporter door;
    private void Start()
    {
        panelManager = FindObjectOfType<PanelManager>();
        if (GetComponent<PersonData>())
        {
            person  = GetComponent<PersonData>();
            person.OnInteractionStart += ActivatePanel;
        }
        else if (GetComponent<DoorTransporter>())
        {
            door = GetComponent<DoorTransporter>();
            door.OnInteractionStart += ActivatePanel;
        }
        
    }
    private void ActivatePanel()
    {
        panelManager.HidePanel();
        panelManager.SetPanelIndex(this);
        panelManager.DisplayPanel();
    }
    private void OnDestroy()
    {
        if (person) person.OnInteractionStart -= ActivatePanel;
        if (door) door.OnInteractionStart -= ActivatePanel;
    }
}
