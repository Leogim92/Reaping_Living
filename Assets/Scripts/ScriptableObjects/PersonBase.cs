using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Person", menuName = "Create New Person")]
public class PersonBase : ScriptableObject
{
    
    PersonDetails _personDetailsDB = null;

    [SerializeField] string firstName ="First Name";
    [SerializeField] string lastName ="Last Name";
    [SerializeField] string story ="Story Description";
    [SerializeField] int age = 0;
    [SerializeField] int eventYear = 0;
    [SerializeField] int lifeExpectancy = 0;

    public KarmaEvent karmaEvent;
    public string Name { get { return firstName + " " + lastName; } }
    public string Story { get { return story; } }
    public int Age { get { return age; } }
    public int EventYear { get { return eventYear; } }
    public int LifeExpectancy
    {
        get { return lifeExpectancy; }
        set { lifeExpectancy = value; }
    }
    public void Initialize (PersonDetails personDetailsDB)
    {
        _personDetailsDB = personDetailsDB;
    }
    public static PersonBase CreateInstance(PersonDetails personDetailsDB)
    {
        var data = ScriptableObject.CreateInstance<PersonBase>();
        data.Initialize(personDetailsDB);
        data.GenerateDetails();
        return data;
    }
    
    private void GenerateDetails()
    {
        firstName = _personDetailsDB.GenerateFirstName();
        lastName = _personDetailsDB.GenerateLastName();
        story = _personDetailsDB.GenerateStory();
        age = _personDetailsDB.GenerateAge();
        lifeExpectancy = _personDetailsDB.GenerateLifeExpectancy(age);
        eventYear = _personDetailsDB.GenerateEventYear(age, lifeExpectancy);
        karmaEvent = _personDetailsDB.GenerateKarmaEvent();
    }

}
