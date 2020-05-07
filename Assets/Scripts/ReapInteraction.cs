using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReapInteraction : MonoBehaviour
{
    [SerializeField] float distanceToInteract = 2f;
    PointManager points;
    Transform hitPoint;

    bool hasInteracted;
    private void Awake()
    {
        points = GetComponent<PointManager>();
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
                    hitPoint = hit.transform;
                    hasInteracted = true;
                }
            }
        }
        if (hasInteracted)
            if (Vector3.Distance(this.transform.position, hitPoint.position) < distanceToInteract)
            {
                TriggerInteractableObject(hitPoint);
                hasInteracted = false;
            }
                
    }
    public void TriggerInteractableObject(Transform hit)
    {
        IMouseInteractable interactableObject = hit.transform.GetComponent<IMouseInteractable>();
        if (interactableObject != null) interactableObject.StartInteraction(points);
    }
}
