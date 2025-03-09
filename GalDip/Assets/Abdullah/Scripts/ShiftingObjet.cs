using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShiftingObjet : MonoBehaviour
{
    //Objects to switch from.
    
    //each object need to define thier layer later
    public GameObject[] ObjectsGroup;
    public int portalRotateAmount= 45;
    int countIndex = 0;

    //Spin degree/array size or matieral size.
    //increase index or decrease.
    //reaching zero or max loop


    //Switch Mirror Matterial half way.

    //Enter the mirror.  
    //switch objects.
    //
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            changeObject();
        }

    }
    public void changeObject()
    {

        gameObject.transform.Rotate(0f, portalRotateAmount, 0f, Space.Self);
        if (ObjectsGroup != null)
        {
            countIndex += 1;
            if (countIndex > ObjectsGroup.Length-1)
            {
                countIndex = 0;

            }
            else if(countIndex < 0)
            {
                countIndex = ObjectsGroup.Length;
            }
            Debug.Log("countIndex: " + countIndex);

        }
    }


        // Play Effect/animation
        // Switch Objects


 

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Switch objects");
            if (ObjectsGroup != null)
            {
                foreach (GameObject group in ObjectsGroup)
                {
                    if (group != ObjectsGroup[countIndex])
                    {
                      //  group.SetActive(false);
                      Transform[] objects = group.GetComponentsInChildren<Transform>();
                        foreach (Transform obj in objects)
                        {
                            obj.gameObject.layer = 7;
                            obj.gameObject.GetComponentInChildren<Collider>().enabled = false;
                        }

                    }
                    else
                    {
                        // group.SetActive(true);
                        Transform[] objects = group.GetComponentsInChildren<Transform>();
                        foreach (Transform obj in objects)
                        {
                            obj.gameObject.layer = 0;
                            obj.gameObject.GetComponentInChildren<Collider>().enabled = true;

                        }

                    }

                }


            }
        }


    }

}
