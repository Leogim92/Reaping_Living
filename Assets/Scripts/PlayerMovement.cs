using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    Camera cameraMain;
    Vector3 playerDestination;
    NavMeshAgent playerNavMesh;
    private void Awake()
    {
        cameraMain = Camera.main;
        playerNavMesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    playerDestination = hit.point;
                }
                playerNavMesh.SetDestination(playerDestination);
            }
        }
    }
}
