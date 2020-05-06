using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =("New Karma Event"),menuName =("Create New Karma Event"))] [System.Serializable]
public class KarmaEvent : ScriptableObject
{
    public enum Karma {good,bad};

    public Karma karmaAlignment = Karma.good;
    public string eventDescription;

}
