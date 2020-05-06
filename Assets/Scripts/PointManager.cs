using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] int yearsCurrency = 20;
    [SerializeField] int karma = 0;
    
    public int YearsCurrency
    {
        get { return yearsCurrency; }
        set { yearsCurrency = value; }
    }
    public int Karma
    {
        get { return karma; }
        set { karma = value; }
    }
    public void UpdateYears(int yearsValue)
    {
        yearsCurrency += yearsValue;
    }
    public void UpdateKarma(int karmaValue)
    {
        karma += karmaValue;
    }
}
