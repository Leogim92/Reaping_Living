using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Point Container",menuName ="Create Point Container")]
public class ReaperStats : ScriptableObject
{
    [SerializeField] int defaultYearsCurrency = 20;
    [SerializeField] int defaultKarma = 0;
    [Space]
    [HideInInspector] public int yearsCurrency;
    [HideInInspector] public int karma; 
    
    private void OnEnable()
    {
        yearsCurrency = defaultYearsCurrency;
        karma = defaultKarma;
    }
}
