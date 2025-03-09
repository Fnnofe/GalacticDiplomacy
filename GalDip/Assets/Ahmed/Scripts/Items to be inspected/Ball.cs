using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IInteractable
{
  public void Interact()
  {
    if (!GetComponent<InspectObject>())
    {
      GetComponent<Rigidbody>().isKinematic = true;
      InspectObject ins = transform.gameObject.AddComponent<InspectObject>();
      ins.ObjectCloseUp();
    }
  }
}
