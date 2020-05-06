using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Person", menuName = "Create New Person")]
public class PersonBase : ScriptableObject
{
    [SerializeField] PersonDetails personDetailsDB = null;

    [SerializeField] string firstName ="First Name";
    [SerializeField] string lastName ="Last Name";
    [SerializeField] string story ="Story Description";
    [SerializeField] int age = 0;
    [SerializeField] int eventYear = 0;
    public KarmaEvent karmaEvent;

    public string Name { get { return firstName + " " + lastName; } }
    public string Story { get { return story; } }
    public int Age { get { return age; } }
    public int EventYear { get { return eventYear; } }

    private void OnEnable()
    {
        Debug.Log("My name is " + Name);
    }
}
