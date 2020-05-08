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
        foreach (PersonData person in peopleInScene)
        {
            if (person.Person.karmaEvent.karmaAlignment == KarmaEvent.Karma.good)
            {
                playerStats.KarmaGoal += playerStats.FullfilledEventValue;
            }
            else
                playerStats.KarmaGoal += playerStats.NonFullfilledEventValue - (person.Person.LifeExpectancy - person.Person.EventYear);
        }
    }


}
