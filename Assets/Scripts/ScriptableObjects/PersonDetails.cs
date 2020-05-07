using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Person Details", menuName ="Create People Details")]
public class PersonDetails : ScriptableObject
{
    [SerializeField] List<string> firstName = null;
    [SerializeField] List<string> lastName = null;
    [SerializeField] List<string> story = null;
    [SerializeField] List<KarmaEvent> goodKarmaEvents = null;
    [SerializeField] List<KarmaEvent> badKarmaEvents = null;

    public string GenerateFirstName()
    {
        int fn = Random.Range(0, firstName.Count);
        return firstName[fn];
    }
    public string GenerateLastName()
    {
        int ln = Random.Range(0, lastName.Count);
        return lastName[ln];
    }
    public string GenerateStory()
    {
        int st = Random.Range(0, story.Count);
        return story[st];
    }
    public int GenerateAge()
    {
        return Random.Range(18, 41);
    }
    public int GenerateEventYear(int age, int lifeExpectancy)
    {
        int extraYears = Random.Range(15, 31);
        return age + extraYears;
    }
    public int GenerateLifeExpectancy(int age)
    {
        int extraYears = Random.Range(30, 61);
        return age + extraYears;
    }
    public KarmaEvent GenerateKarmaEvent()
    {
        int eventChance = Random.Range(0, 2);
        if (eventChance == 0)
        {
            return goodKarmaEvents[Random.Range(0, goodKarmaEvents.Count)];
        }
        else
            return badKarmaEvents[Random.Range(0, badKarmaEvents.Count)];
    }
}
