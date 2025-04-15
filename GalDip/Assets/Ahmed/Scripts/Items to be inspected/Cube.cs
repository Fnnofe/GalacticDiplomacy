using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour, IInteractable
{
    private Material mat;
    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    public void Interact()
    {
        mat.SetColor("_BaseColor", new Color(0.29f, 1f, 0.12f));
        Debug.Log("Cube interacted");
    }
    public void Observe()
    {
        
    }
}
