using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Point Container",menuName ="Create Point Container")]
public class ReaperStats : ScriptableObject
{
    [SerializeField] int defaultYearsCurrency = 20;
    [SerializeField] int defaultKarma = 0;
    [SerializeField] int defaultYearsCurrencyTotal = 100;
    [SerializeField] int defaultKarmaEventOnValue = 50;
    [SerializeField] int defaultKarmaEventOffValue = -25;
    [SerializeField] int defaultKarmaYearModifier = 1;
    [SerializeField] int defaultNavMeshSpeed = 10;
    [SerializeField] int defaultInteractionRange = 4;

    [Space]
    [HideInInspector] public int yearsCurrency;
    [HideInInspector] public int karma;
    [HideInInspector] public int yearsCurrencyTotal;
    [HideInInspector] public int karmaEventOnValue;
    [HideInInspector] public int karmaEventOffValue;
    [HideInInspector] public int karmaYearModififer;
    [HideInInspector] public int navMeshSpeed;
    [HideInInspector] public int interactionRange; 

    private void OnEnable()
    {
        yearsCurrency = defaultYearsCurrency;
        karma = defaultKarma;
        yearsCurrencyTotal = defaultYearsCurrencyTotal;
        karmaEventOnValue = defaultKarmaEventOnValue;
        karmaEventOffValue = defaultKarmaEventOffValue;
        karmaYearModififer = defaultKarmaYearModifier;
        navMeshSpeed = defaultNavMeshSpeed;
        interactionRange = defaultInteractionRange;
    }
}
