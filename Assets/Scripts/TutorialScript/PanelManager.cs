using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] List<TutorialPanelLink> linkedPanelTriggers = null;
    [SerializeField] List<GameObject> tutorialPanels = null;
    int panelIndex;
    private void Awake()
    {
        GetTutorialPanelsInScene();
    }

    private void GetTutorialPanelsInScene()
    {
        
        foreach (Image panel in GetComponentsInChildren<Image>())
        {
            if (!panel.gameObject.GetComponent<Button>())
            {
                tutorialPanels.Add(panel.gameObject);
                panel.gameObject.SetActive(false);
            }
        }
    }
    public void DisplayPanel()
    {
        tutorialPanels[panelIndex].SetActive(true);
    }
    public void HidePanel()
    {
        tutorialPanels[panelIndex].SetActive(false);
    }

    public void SetPanelIndex(TutorialPanelLink linkedObject)
    {
        panelIndex = linkedPanelTriggers.IndexOf(linkedObject);
    }
}
