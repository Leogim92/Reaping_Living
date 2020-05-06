using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonData : MonoBehaviour, IMouseInteractable
{
    [SerializeField] Texture2D mouseCursor;
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



    private void OnMouseOver()
    {
        ChangeMouseCursor(mouseCursor);
    }
    private void OnMouseExit()
    {
        ChangeMouseCursor(default);
    }

    public void ChangeMouseCursor(Texture2D mouseCursor)
    {
        Cursor.SetCursor(mouseCursor, Vector2.zero, CursorMode.Auto);
    }
}
