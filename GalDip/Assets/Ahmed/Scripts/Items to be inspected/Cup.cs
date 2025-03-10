using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cup : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Cup Interacted");
        if (!GetComponent<InspectObject>())
        {
            InspectObject ins = transform.parent.gameObject.AddComponent<InspectObject>();
            ins.ObjectCloseUp();
        }
    }
}
