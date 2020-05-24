using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSoundIcon : MonoBehaviour
{
    [SerializeField] Image soundIcon =null;
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
        if (soundState) soundIcon.enabled = true;
        else soundIcon.enabled = false;
    }
    private void OnDestroy()
    {
        InGameMenusManager.OnSoundTrigger -= SoundButtonVisual;
    }
}
