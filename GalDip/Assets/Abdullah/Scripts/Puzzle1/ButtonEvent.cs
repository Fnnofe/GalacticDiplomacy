using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour, IInteractable
{
    public UnityEvent startEvent;
    //[SerializeField] AudioSource audioSource;
    public void Interact()
    {
        startEvent.Invoke();
        //audioSource.Play();
    }

    public void Observe()
    {
        InteractbleDialouge.Instance.ShowText("Activate");

        
    }
}
