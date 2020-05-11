using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTest : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;
    private void Awake()
    {
        if (FindObjectsOfType<SingletonTest>().Length > 1) Destroy(this);
        else DontDestroyOnLoad(this);
    }
}
