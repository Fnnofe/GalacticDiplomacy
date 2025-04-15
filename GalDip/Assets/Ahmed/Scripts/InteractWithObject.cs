using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour  
{
    private RaycastHit ray;
    private bool interacting;
    [HideInInspector] public GameObject go;
    

   

    void Update()
    {
        var inspectedobject = GetFacingObject();
        if(inspectedobject == null)return;
        var interactble = inspectedobject.GetComponent<IInteractable>();
        if (interactble != null)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0) && !interacting)
            {
                interactble.Interact();
                interacting = true;
            }
            if(!interacting) interactble.Observe();

            if (Input.GetKeyDown(KeyCode.Mouse1) && interacting)
            {
                interacting = false;
            }
        }
        else
        {
            InteractbleDialouge.Instance.ShowText("");
        }
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
