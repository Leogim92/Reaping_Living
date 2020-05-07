using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] Canvas fadeCanvas=null;
    private void Awake()
    {
        DoorTransporter.OnDoorEnter += FadeInOut;
    }

    private void FadeInOut()
    {
        FadeTrigger();
    }
    void FadeTrigger()
    {
        fadeCanvas.GetComponent<Animator>().SetTrigger("Fade");
    }
}
