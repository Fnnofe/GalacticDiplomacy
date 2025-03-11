using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] string keyText = "I Found a Rusted Key Inside!";
    
    public void Interact()
    {
        InteractbleDialouge.Instance.ShowText(keyText);
        PlayerInventory.Instance.AddItem("Rusted Key");
        FindObjectOfType<InspectObject>().DestroyInspector();
        Destroy(gameObject);
    }
}
