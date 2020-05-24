using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuSoundText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soundText =null;
    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Start()
    {
        SoundButtonVisual(playerStats.IsSoundOn);
        InGameMenusManager.OnSoundTrigger += SoundButtonVisual;
    }
    void SoundButtonVisual(bool soundState)
    {
        if (soundState) soundText.text = "Sound On";
        else soundText.text = "Sound Off";
    }
    private void OnDestroy()
    {
        InGameMenusManager.OnSoundTrigger -= SoundButtonVisual;
    }
}
