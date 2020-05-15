using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class DoorTransporter : MonoBehaviour, IMouseInteractable
{
    public event Action OnInteractionStart;
    public static event Action OnDoorEnter;
    public event Action OnSpecificDoorEnter;

    [SerializeField] Texture2D mouseCursor = null;
    [SerializeField] Transform destinationPoint = null;
    [SerializeField] float warpDelay = 1.5f;

    
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
        OnDoorEnter?.Invoke();
        OnSpecificDoorEnter?.Invoke();
        NavMeshAgent playerAI = playerStats.transform.GetComponent<NavMeshAgent>();
        StartCoroutine(WarpPlayer(playerAI));
    }
    IEnumerator WarpPlayer(NavMeshAgent playerAI)
    {
        yield return new WaitForSeconds(warpDelay);
        OnInteractionStart?.Invoke();
        playerAI.Warp(destinationPoint.position);
    }
}
