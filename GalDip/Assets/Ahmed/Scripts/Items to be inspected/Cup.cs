using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cup : MonoBehaviour, IInteractable
{
    [SerializeField] string cupText = "Its a Cup";

    public void Interact()
    {
        if (!GetComponent<InspectObject>())
        {
            InteractbleDialouge.Instance.ShowText(cupText);
            InspectObject ins = transform.gameObject.AddComponent<InspectObject>();
            ins.ObjectCloseUp();
        }
    }
}
