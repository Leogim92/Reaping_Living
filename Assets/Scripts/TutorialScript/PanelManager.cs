﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public static event Action OnUITrigger;

    [SerializeField] List<TutorialPanelLink> linkedPanelTriggers = null;
    [Space]
    [SerializeField] GameObject firstPanel = null;
    [Space]
    [SerializeField] List<GameObject> tutorialPanels = null;

    int panelIndex = 0;
    public void DisplayPanel()
    {
        tutorialPanels[panelIndex].SetActive(true);
    }
    public void HidePanel()
    {
        if(firstPanel) firstPanel.SetActive(false);
        tutorialPanels[panelIndex].SetActive(false);
    }
    public void ClosePanel()
    {
        HidePanel();
        OnUITrigger?.Invoke();
    }

    public void SetPanelIndex(TutorialPanelLink linkedObject)
    {
        panelIndex = linkedPanelTriggers.IndexOf(linkedObject);
    }
}
