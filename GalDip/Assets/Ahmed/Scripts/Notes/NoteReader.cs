using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteReader : MonoBehaviour, IInteractable
{
    [SerializeField] private string text = "\"Dave...\nI don’t know if you’ve noticed," +
                                           " but the mirror in this room—it shows things. " +
                                           "Things that aren't there when I turn away. " +
                                           "I thought it was stress, but it’s more than that.\n\nThere’s something in this room watching me, " +
                                           "hiding behind that reflection. I tried to touch it, but my hand went through air... while the mirror showed it grabbing mine.\n— M.\"";
    public void Interact()
    {
        Debug.Log("Interact");
        InteractbleDialouge.Instance.ShowText(text);
        InspectObject ins = gameObject.AddComponent<InspectObject>();
        ins.ObjectCloseUp();
       
    }
    public void Observe()
    {
        InteractbleDialouge.Instance.ShowText("there is a note!");
    }
}
