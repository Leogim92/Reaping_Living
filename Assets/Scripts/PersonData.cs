using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PersonData : MonoBehaviour, IMouseInteractable
{
    GiftReapUI giftReapUI;
    [SerializeField] Texture2D mouseCursor=null;
    [SerializeField] PersonDetails personDetailsDB =null;
    PersonBase person = null;
    bool isFateSealed = false;
    private void Awake()
    {
        giftReapUI = FindObjectOfType<GiftReapUI>();
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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            ChangeMouseCursor(mouseCursor);
        }
    }
    private void OnMouseExit()
    {
        ChangeMouseCursor(default);
    }

    public void ChangeMouseCursor(Texture2D mouseCursor)
    {
        Cursor.SetCursor(mouseCursor, Vector2.zero, CursorMode.Auto);
    }
    public void StartInteraction(PointManager playerPoints)
    {
        giftReapUI.PassReaperAndPersonData(this, playerPoints);
        giftReapUI.TriggerReapGiftUI(true);
        StartCoroutine(DefaultCursor());
    }
    IEnumerator DefaultCursor()
    {
        yield return new WaitForSeconds(0.00001f);
        ChangeMouseCursor(default);

    }
}
