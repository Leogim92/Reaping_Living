using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] ReaperStats reaperStats = null;
    public int YearsCurrency
    {
        get { return reaperStats.yearsCurrency; }
        set { reaperStats.yearsCurrency = value; }
    }
    public int Karma
    {
        get { return reaperStats.karma; }
        set { reaperStats.karma = value; }
    }
    public int TotalYears
    {
        get { return reaperStats.yearsCurrencyTotal; }
        set { reaperStats.yearsCurrencyTotal = value; }
    }
    public int KarmaEventOn
    {
        get { return reaperStats.karmaEventOnValue; }
        set { reaperStats.karmaEventOnValue = value; }
    }
    public int KarmaEventOff
    {
        get { return reaperStats.karmaEventOffValue; }
        set { reaperStats.karmaEventOffValue = value; }
    }
    public int KarmaYearModifier
    {
        get { return reaperStats.karmaYearModififer; }
        set { reaperStats.karmaYearModififer = value; }
    }
    public int NavMeshSpeed
    {
        get { return reaperStats.navMeshSpeed; }
        set { reaperStats.navMeshSpeed = value; }
    }
    public int InteractionRange
    {
        get { return reaperStats.interactionRange; }
        set { reaperStats.interactionRange = value; }
    }
}
