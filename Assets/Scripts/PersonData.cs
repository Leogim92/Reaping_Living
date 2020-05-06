using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonData : MonoBehaviour
{
    [SerializeField] PersonDetails personDetailsDB =null;
    PersonBase person = null;
    bool isFateSealed = false;
    private void Awake()
    {
        person = PersonBase.CreateInstance(personDetailsDB);
    }
    public bool IsFateSealed
    {
        get { return isFateSealed; }
        set { isFateSealed = value; }
    }
    
    public PersonBase Person { get { return person; } }
}
