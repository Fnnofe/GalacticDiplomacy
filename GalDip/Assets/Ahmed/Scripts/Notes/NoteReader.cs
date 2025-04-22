using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteReader : MonoBehaviour, IInteractable
{
    [TextArea(5, 10)]
    [SerializeField] private string text;
    public GameObject UIControls;

    public void Interact()
    {
        Debug.Log("Interact");
        InteractbleDialouge.Instance.ShowText(text);
        InspectObject ins = gameObject.AddComponent<InspectObject>();
        ins.ObjectCloseUp();
        ins.controlUI = UIControls;

    }
    public void Observe()
    {
        InteractbleDialouge.Instance.ShowText("there is a note!");
    }
}
