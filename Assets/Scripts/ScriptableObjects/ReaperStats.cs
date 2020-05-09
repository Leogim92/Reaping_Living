using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Point Container",menuName ="Create Point Container")]
public class ReaperStats : ScriptableObject
{
    [SerializeField] int defaultYearsCurrency = 20;
    [SerializeField] int defaultKarma = 0;
    [Space]
    [SerializeField] int defaultGoodEventsDone = 0;
    [SerializeField] int defaultBadEventsAvoided = 0;
    [Space]
    [SerializeField] int defaultYearsCurrencyTotal = 100;
    [SerializeField] int defaultGoodKarmaEventBonus = 0;
    [SerializeField] int defaultBadKarmaEventBonus = 0;
    [SerializeField] int defaultNavMeshSpeed = 10;
    [SerializeField] int defaultInteractionRange = 4;
    [Space]
    [SerializeField] int defaultKarmaGoal=0;

    [Space]
    public int fullfilledEventValue = 50;
    public int nonFullfilledEventValue = 25;

    //
    [HideInInspector] public int yearsCurrency;
    [HideInInspector] public int karma;
    [HideInInspector] public int goodEventsDone;
    [HideInInspector] public int badEventsAvoided;


    [HideInInspector] public int yearsCurrencyTotal;
    [HideInInspector] public int goodKarmaEventBonus;
    [HideInInspector] public int badKarmaEventBonus;
    [HideInInspector] public int navMeshSpeed;
    [HideInInspector] public int interactionRange;

    [HideInInspector] public int karmaGoal;


    //extra HACK
    [Space]
    public bool isSoundOn=true;
    public void ResetReaperStats()
    {
        yearsCurrency = defaultYearsCurrency;
        karma = defaultKarma;
        goodEventsDone = defaultGoodEventsDone;
        badEventsAvoided = defaultBadEventsAvoided;

        yearsCurrencyTotal = defaultYearsCurrencyTotal;
        goodKarmaEventBonus = defaultGoodKarmaEventBonus;
        badKarmaEventBonus = defaultBadKarmaEventBonus;
        navMeshSpeed = defaultNavMeshSpeed;
        interactionRange = defaultInteractionRange;

        karmaGoal = defaultKarmaGoal;
    }
}
