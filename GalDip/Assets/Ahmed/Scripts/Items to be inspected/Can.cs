using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (!GetComponent<InspectObject>())
        {
            InspectObject ins = transform.gameObject.AddComponent<InspectObject>();
            ins.ObjectCloseUp();
        }
    }
    public void Observe()
    {
        
    }
}
