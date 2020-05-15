using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapedHousesMarker : MonoBehaviour
{
    [SerializeField] DoorTransporter exitDoor;
    [SerializeField] GameObject scytheMark;
    [SerializeField] GameObject reaperHeadMark;
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
