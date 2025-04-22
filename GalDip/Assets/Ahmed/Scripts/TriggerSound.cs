using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerSound : MonoBehaviour
{
    public UnityEvent startEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startEvent.Invoke();
            Destroy(this.gameObject);
        }
        
    }
}
