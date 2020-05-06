using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Person Details", menuName ="Create People Details")]
public class PersonDetails : ScriptableObject
{
    [SerializeField] List<string> firstName = null;
    [SerializeField] List<string> lastName = null;
    [SerializeField] List<string> story = null;
    int age = 0;
    int eventYear = 0;
    [SerializeField] List<KarmaEvent> goodKarmaEvents = null;
    [SerializeField] List<KarmaEvent> badKarmaEvents = null;

    public string GenerateName()
    {
        int fn = Random.Range(0, firstName.Count - 1);
        int ln = Random.Range(0, lastName.Count - 1);
        string personName = firstName[fn] + lastName[ln];
        return personName;
    }
}
