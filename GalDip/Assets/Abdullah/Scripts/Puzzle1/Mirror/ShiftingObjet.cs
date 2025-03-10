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
    public int[] switchingSequance;
    int currentSequnce;


    //Spin degree/array size or matieral size.
    //increase index or decrease.
    //reaching zero or max loop


    //Switch Mirror Matterial half way.

    //Enter the mirror.  
    //switch objects.
    //

    public void ChangeObject()
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

        //switching material for the mirror. (W.I.P) for later
        if (switchingSequance != null)
        {
            //Switching sequance
            currentSequnce += 1;
            if (currentSequnce > switchingSequance.Length - 1)
            {
                currentSequnce = 0;

            }
            else if (countIndex < 0)
            {
                currentSequnce = switchingSequance.Length;
            }

            //switching material for the mirror.

        }

    }


    // Play Effect/animation




    public void OnTriggerEnter(Collider other)
    {
        //check if the playered crossed
        if (other.tag == "Player")
        {
            if (ObjectsGroup != null)
            {
                //Process each group 
                foreach (GameObject group in ObjectsGroup)
                {
                    //hide objects by changing the layer.
                    //disable Collider.
                    if (group != ObjectsGroup[countIndex])
                    {
                      //  group.SetActive(false);
                      Transform[] objects = group.GetComponentsInChildren<Transform>();
                        foreach (Transform obj in objects)
                        {
                            obj.gameObject.layer = (int)group.GetComponent<GroupInfo>().layer;
                            obj.gameObject.GetComponentInChildren<Collider>().enabled = false;
                        }

                    }

                    //Manfist Objects by changing the layer
                    //Enable Collider.
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
