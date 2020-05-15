using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesMarker : MonoBehaviour
{
    [SerializeField] DoorTransporter exitDoor = null;
    [SerializeField] GameObject scytheMark = null;
    [SerializeField] GameObject reaperHeadMark = null;
    PersonData[] peopleInHouse;
    private void Awake()
    {
        peopleInHouse = GetComponentsInChildren<PersonData>();
    }
    void Start()
    {
        exitDoor.OnSpecificDoorEnter += MarkReapedHouses; 
    }
    void MarkReapedHouses()
    {
        if (peopleInHouse.Length == 0) return;
        foreach (PersonData person in peopleInHouse)
        {
            if (!person.IsFateSealed)
            {
                return;
            }
        }
        ChangeMarkOnBuilding();
    }

    private void ChangeMarkOnBuilding()
    {
        scytheMark.SetActive(false);
        reaperHeadMark.SetActive(true);
    }
}
