using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateKarmaGoal : MonoBehaviour
{
    const int EVENT_DONE_BONUS = 40;
    const int EVENT_NOTDONE_BONUS = 20;

    PlayerStats playerStats;
    PersonData[] peopleInScene;
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        peopleInScene = FindObjectsOfType<PersonData>();
    }
    private void Start()
    {
        CalculateGoal();
    }

    private void CalculateGoal()
    {
        foreach (PersonData person in peopleInScene)
        {
            if (person.Person.karmaEvent)
            {
                if (person.Person.karmaEvent.karmaAlignment == KarmaEvent.Karma.good)
                {
                    playerStats.KarmaGoal += EVENT_DONE_BONUS + (person.Person.LifeExpectancy - person.Person.EventYear);
                }
                else
                {
                    playerStats.KarmaGoal += EVENT_NOTDONE_BONUS - (person.Person.LifeExpectancy - person.Person.EventYear);
                }
            }
        }
    }
}
