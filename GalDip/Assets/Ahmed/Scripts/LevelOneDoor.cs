using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneDoor : MonoBehaviour
{
    [SerializeField] private string requiredKey = "Rusted Key";
    private RaycastHit ray;

    private void Update()
    {
        bool objectHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out ray ,3f);
        
        if (objectHit)
        {
            var door = ray.collider.gameObject;
            if (Input.GetKeyDown(KeyCode.E) && door.GetComponent<LevelOneDoor>())
            {
                if (PlayerInventory.Instance.HasItem(requiredKey))
                {
                    PlayerInventory.Instance.RemoveItem(requiredKey);
                    InteractbleDialouge.Instance.ShowText("I Opened the door");
                    OpenDoor();
                }
                else
                {
                    InteractbleDialouge.Instance.ShowText("I need a key to open the door!");
                }
            }
        }
       
    }

    private void OpenDoor()
    {
        // put animation and stuff.
        Debug.Log("Door is opening...");
        Destroy(gameObject);
    }
}
