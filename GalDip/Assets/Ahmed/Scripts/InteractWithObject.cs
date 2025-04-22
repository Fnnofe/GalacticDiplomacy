using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour  
{
    private RaycastHit ray;
    [HideInInspector] public GameObject go;
    private bool interacting;
    

   

    void Update()
    {
        var inspectedobject = GetFacingObject();
        if(inspectedobject == null)return;
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
        bool objHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out ray, 3f);
        if (objHit)
        {
            return ray.collider.gameObject;
        }
        return null;
    }
}
