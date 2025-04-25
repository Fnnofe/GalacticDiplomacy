using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InteractWithObject : MonoBehaviour  
{
    private RaycastHit ray;
    [HideInInspector] public GameObject go;
    private bool interacting;
    

   

    void Update()
    {
        var inspectedobject = GetFacingObject();
        if (inspectedobject == null)
        {
            //deslecet when not on interactable 
            InteractbleDialouge.Instance.ShowText("");

            return;
        }
        var interactble = inspectedobject.GetComponent<IInteractable>();
        if (interactble != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !interacting)
            {
                interactble.Interact();
                interacting = true;
            }
            if(!inspectedobject.GetComponent<InspectObject>())
            {
                interactble.Observe();
                interacting = false;
            }
        }
        else if(!interacting) InteractbleDialouge.Instance.ShowText("");

    }

    public GameObject GetFacingObject()
    {
        Ray MousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool objHit = Physics.Raycast(MousePos, out ray, 3f);
        if (objHit)
        {
            return ray.collider.gameObject;
        }

        return null;
    }
}
