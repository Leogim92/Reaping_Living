using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonData : MonoBehaviour
{
    [SerializeField] PersonBase person = null;
    [SerializeField] int lifeExpectancy = 0;
    bool isFateSealed = false;
    public bool IsFateSealed
    {
        get { return isFateSealed; }
        set { isFateSealed = value; }
    }
    public int LifeExpectancy
    {
        get { return lifeExpectancy; }
        set { lifeExpectancy = value; }
    }

    public PersonBase Person { get { return person; } }
}
