using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class DoorTransporter : MonoBehaviour, IMouseInteractable
{
    [SerializeField] Texture2D mouseCursor = null;
    [SerializeField] Transform destinationPoint = null;
    [SerializeField] float warpDelay = 1.5f;

    public static event Action OnDoorEnter;
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
        OnDoorEnter?.Invoke();
        NavMeshAgent playerAI = playerPoints.transform.GetComponent<NavMeshAgent>();
        StartCoroutine(WarpPlayer(playerAI));
    }
    IEnumerator WarpPlayer(NavMeshAgent playerAI)
    {
        yield return new WaitForSeconds(warpDelay);
        playerAI.Warp(destinationPoint.position);
    }
}
