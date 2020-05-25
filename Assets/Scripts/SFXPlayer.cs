using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] AudioClip doorSFX = null;
    [SerializeField] AudioClip unsealedSFX = null;
    [SerializeField] AudioClip giftReapSFX = null;
    [SerializeField] AudioClip sealFateSFX = null;
    [SerializeField] AudioClip gameOverSFX = null;
    [SerializeField] AudioClip uiTriggerSFX = null;

    AudioSource audioSource;
    private void Awake()
    {
        int numbSFXPlayers = FindObjectsOfType<SFXPlayer>().Length;
        if (numbSFXPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        DoorTransporter.OnDoorEnter += DoorSFX;
        NextLevelTrigger.OnUnsealedFates += UnsealedSFX;
        NextLevelTrigger.OnKarmaGoalFailed += GameOverSFX;
        GiftReapUI.OnGiftReap += GiftReapSFX;
        GiftReapUI.OnFateSeal += SealFateSFX;
        GiftReapUI.OnUITrigger += UISound;
        InGameMenusManager.OnUITrigger += UISound;
        PanelManager.OnUITrigger += UISound;
        
        
    }
    void DoorSFX() => audioSource.PlayOneShot(doorSFX);
    void UnsealedSFX() => audioSource.PlayOneShot(unsealedSFX);
    void GiftReapSFX() => audioSource.PlayOneShot(giftReapSFX);
    void SealFateSFX() => audioSource.PlayOneShot(sealFateSFX);
    void GameOverSFX() => audioSource.PlayOneShot(gameOverSFX);
    void UISound() => audioSource.PlayOneShot(uiTriggerSFX);


    private void OnDestroy()
    {
        DoorTransporter.OnDoorEnter -= DoorSFX;
        NextLevelTrigger.OnUnsealedFates -= UnsealedSFX;
        NextLevelTrigger.OnKarmaGoalFailed -= GameOverSFX;
        GiftReapUI.OnGiftReap -= GiftReapSFX;
        GiftReapUI.OnFateSeal -= SealFateSFX;
        GiftReapUI.OnUITrigger -= UISound;
        InGameMenusManager.OnUITrigger -= UISound;
        PanelManager.OnUITrigger -= UISound;
    }



}
