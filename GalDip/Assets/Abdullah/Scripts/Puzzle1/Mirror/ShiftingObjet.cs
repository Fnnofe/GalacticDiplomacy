using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ShiftingObjet : MonoBehaviour
{
    //Objects to switch from.

    //each object need to define thier layer later
    [Header("Puzzle setup")]
    [Tooltip("Set of objects to cycle through")]
    public GameObject[] objectsGroup;
    [Tooltip("Match the mirror to what mask and cycle through")]
    public int[] switchingSequance;
    public int portalRotateAmount = 45;
    public int numberOfCycles=1;
    int cycle=1;

    [Header("Setup.Always the same")]
    public Material[] MaskMaterials;
    public MeshRenderer Mirroglass;

    int currentSequnce;
    int countIndex = 0;




    public void Start()
    {
    }
    public void ChangeObject()
    {

        //reset the rotation cycle
        cycle++;
        if (cycle > numberOfCycles) cycle = 1;

        //Objects appears after entering the portal
        if (objectsGroup != null)
        {
            countIndex += 1;
            if (countIndex > objectsGroup.Length-1)
            {
                countIndex = 0;

            }
            else if(countIndex < 0)
            {
                countIndex = objectsGroup.Length;
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
            Mirroglass.material = MaskMaterials[switchingSequance[currentSequnce]];
        }

    }
    // Play Effect/animation
    public void Update()
    {
        var target = Quaternion.Euler(gameObject.transform.rotation.x, portalRotateAmount * cycle, gameObject.transform.rotation.z);
        gameObject.transform.localRotation = Quaternion.Slerp(gameObject.transform.localRotation, target, Time.deltaTime * 5 * 2);
        


    }

    public void OnTriggerEnter(Collider other)
    {
        //check if the playered crossed
        if (other.tag == "Player")
        {
            if (objectsGroup != null)
            {
                //Process each group 
                foreach (GameObject group in objectsGroup)
                {
                    //hide objects by changing the layer.
                    //disable Collider.
                    if (group != objectsGroup[countIndex])
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
