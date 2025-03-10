using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    private RaycastHit ray;
    public GameObject go;
 
    void Update()
    {
        var inspectedobject = GetFacingObject();
        if(inspectedobject == null)return;
        var interactble = inspectedobject.GetComponent<IInteractable>();
        if (interactble != null)
        {
            interactble.Interact();
            go = inspectedobject;
        }
        
    }

    public GameObject GetFacingObject()
    {
        bool objHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out ray, 3f);
        if (Input.GetKeyDown(KeyCode.Mouse0) && objHit)
        {
            return ray.collider.gameObject;
        }
        return null;
    }
}
