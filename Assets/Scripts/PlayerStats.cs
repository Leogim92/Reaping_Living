using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] ReaperStats reaperStats = null;
    public int FullfilledEventValue
    {
        get { return reaperStats.fullfilledEventValue; }
        set { reaperStats.fullfilledEventValue = value; }
    }
    public int NonFullfilledEventValue
    {
        get { return reaperStats.nonFullfilledEventValue; }
        set { reaperStats.nonFullfilledEventValue = value; }
    }
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
    public int GoodKarmaBonus
    {
        get { return reaperStats.goodKarmaEventBonus; }
        set { reaperStats.goodKarmaEventBonus = value; }
    }
    public int BadKarmaBonus
    {
        get { return reaperStats.badKarmaEventBonus; }
        set { reaperStats.badKarmaEventBonus = value; }
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
    public int KarmaGoal
    {
        get { return reaperStats.karmaGoal; }
        set { reaperStats.karmaGoal = value; }
    }
    public void ResetReaperStats()
    {
        reaperStats.ResetReaperStats();
    }
}
