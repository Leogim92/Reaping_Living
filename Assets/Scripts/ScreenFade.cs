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
        NextLevelTrigger.OnNextLevelTrigger += FadeInOut;
    }

    private void FadeInOut()
    {
        fadeCanvas.GetComponent<Animator>().SetTrigger("Fade");
    }
    private void OnDestroy()
    {
        DoorTransporter.OnDoorEnter -= FadeInOut;
        NextLevelTrigger.OnNextLevelTrigger -= FadeInOut;
    }
}
