using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    Vector3 playerDestination;
    NavMeshAgent playerNavMesh;
    private void Awake()
    {
        playerNavMesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    playerDestination = hit.point;
                }
                playerNavMesh.SetDestination(playerDestination);
            }
        }
    }
}
