using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonRandomizer : MonoBehaviour
{
    [SerializeField] Transform leftButton=null;
    [SerializeField] Transform rightButton =null;
    [Space]
    [SerializeField] List<GameObject> buttons = null;
    
    void Start()
    {
        GetButton(leftButton);
        GetButton(rightButton);
    }

    private void GetButton(Transform buttonPosition)
    {
        GameObject button = GenerateButton();
        button.transform.SetParent(buttonPosition);
        button.transform.localPosition = Vector2.zero;
        button.SetActive(true);
    }

    private GameObject GenerateButton()
    {
        int buttonIndex = Random.Range(0, buttons.Count);
        GameObject button = buttons[buttonIndex];
        buttons.Remove(button);
        return button;
    }
}
