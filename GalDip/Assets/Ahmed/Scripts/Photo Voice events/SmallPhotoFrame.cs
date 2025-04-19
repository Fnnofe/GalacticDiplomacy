using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SmallPhotoFrame : MonoBehaviour, IInteractable
{
   public UnityEvent startEvent;

   public void Interact()
   {
      startEvent.Invoke();
      InspectObject ins = gameObject.AddComponent<InspectObject>();
      ins.ObjectCloseUp();
   }

   public void Observe()
   {
      InteractbleDialouge.Instance.ShowText("Its a small photo frame");
   }
}
