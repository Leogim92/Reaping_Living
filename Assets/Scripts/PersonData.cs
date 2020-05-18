using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PersonData : MonoBehaviour, IMouseInteractable
{
    public event Action OnInteractionStart;

    GiftReapUI giftReapUI;
    [SerializeField] Sprite photo = null;
    [SerializeField] Texture2D mouseCursor=null;
    [SerializeField] PersonDetails personDetailsDB =null;
    [SerializeField] PersonBase person = null;
    [SerializeField] bool isRandomlyGenerated = false;
    bool isFateSealed = false;
    private void Awake()
    {
        giftReapUI = FindObjectOfType<GiftReapUI>();
        if(isRandomlyGenerated)person = PersonBase.CreateInstance(personDetailsDB);
    }
    public bool IsFateSealed
    {
        get { return isFateSealed; }
        set { isFateSealed = value; }
    }
    public Sprite Photo
    {
        get { return photo; }
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
    public void StartInteraction(PlayerStats playerStats)
    {
        giftReapUI.PassReaperAndPersonData(this, playerStats);
        giftReapUI.TriggerReapGiftUI(true);
        StartCoroutine(DefaultCursor());
        OnInteractionStart?.Invoke();
    }
    IEnumerator DefaultCursor()
    {
        yield return new WaitForSeconds(0.00001f);
        ChangeMouseCursor(default);

    }
}
