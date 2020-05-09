﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateKarmaGoal : MonoBehaviour
{
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
                    playerStats.KarmaGoal += playerStats.FullfilledEventValue + (person.Person.LifeExpectancy - person.Person.EventYear);
                }
                else
                {
                    playerStats.KarmaGoal += playerStats.NonFullfilledEventValue - (person.Person.LifeExpectancy - person.Person.EventYear);
                }
            }
        }
        print(playerStats.KarmaGoal);
    }
}
