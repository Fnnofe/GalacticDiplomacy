using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour, IInteractable
{
    public UnityEvent startEvent;
    public void Interact()
    {
        startEvent.Invoke();
    }
}
