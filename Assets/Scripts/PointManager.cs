using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] PointContainer pointContainer = null;
    public int YearsCurrency
    {
        get { return pointContainer.yearsCurrency; }
        set { pointContainer.yearsCurrency = value; }
    }
    public int Karma
    {
        get { return pointContainer.karma; }
        set { pointContainer.karma = value; }
    }
    public void UpdateYears(int yearsValue)
    {
        pointContainer.yearsCurrency += yearsValue;
    }
    public void UpdateKarma(int karmaValue)
    {
        pointContainer.karma += karmaValue;
    }
}
