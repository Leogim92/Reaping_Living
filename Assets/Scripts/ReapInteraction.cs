using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReapInteraction : MonoBehaviour
{
    [SerializeField] float distanceToInteract = 2f;
    PointManager points;
    private void Awake()
    {
        points = GetComponent<PointManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        IMouseInteractable interactableObject = other.transform.GetComponent<IMouseInteractable>();
        if (interactableObject != null) interactableObject.StartInteraction(points);
        Debug.Log("On trigger enter");
    }
    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit) && Vector3.Distance(this.transform.position, hit.transform.position) < distanceToInteract)
                {
                    IMouseInteractable interactableObject = hit.transform.GetComponent<IMouseInteractable>();
                    if (interactableObject != null) interactableObject.StartInteraction(points);
                }
            }
        }
    }
}
