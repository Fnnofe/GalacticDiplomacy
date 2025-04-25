using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LargePhoto : MonoBehaviour, IInteractable
{
    public UnityEvent startEvent;
    public GameObject UIControls;
    public string displayText;
    public GameObject hideRoom;
     private Collider boxCollider;
    public void Interact()
    {
        startEvent.Invoke();
        InspectObject ins = gameObject.AddComponent<InspectObject>();
        ins.ObjectCloseUp();
        ins.controlUI = UIControls;
    }
    void Start()
    {
        boxCollider = gameObject.GetComponent<Collider>();

    }
void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            boxCollider.enabled = true;
            hideRoom.SetActive(false);
        }
    }
    public void Observe()
    {
        InteractbleDialouge.Instance.ShowText(displayText);
    }
}
