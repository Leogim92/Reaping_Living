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
    public void UpdateYears(int yearsValue)
    {
        reaperStats.yearsCurrency += yearsValue;
    }
    public void UpdateKarma(int karmaValue)
    {
        reaperStats.karma += karmaValue;
    }
}
