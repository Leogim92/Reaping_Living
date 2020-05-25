using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] musicBG =null;
    AudioSource audioSource;
    private int i;

    private void Awake()
    {
        int numbMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numbMusicPlayers > 1)
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
        InGameMenusManager.OnSoundTrigger += SetVolume;
        StartCoroutine(Playlist());
    }
    void SetVolume(bool soundState)
    {
        if (soundState) audioSource.volume = 1;
        else audioSource.volume = 0;
    }
    IEnumerator Playlist()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!audioSource.isPlaying)
            {
                if(i != (musicBG.Length - 1))
                {
                    i++;
                    audioSource.clip = musicBG[i];
                    audioSource.Play();
                }
                else
                {
                    i = 0;
                    audioSource.clip = musicBG[i];
                    audioSource.Play();
                }
            }
        }
    }
    private void OnDestroy()
    {
        InGameMenusManager.OnSoundTrigger -= SetVolume;
    }
}
