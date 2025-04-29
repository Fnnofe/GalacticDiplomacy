using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoors : MonoBehaviour
{
    public Transform player;
    public GameObject[] adjustenWalls;
    public Transform artficat;
    public Transform artifactNewPosition;
    public Transform artifactOldPosition;
    public bool reset = false;
    public Transform restPos;

    float dot;
    // Start is called before the first frame update


    private void Update()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        dot = Vector3.Dot(transform.forward, toPlayer);

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (reset==false)
            {
                if (dot < 0) // Player is behind
                {
                    if (artifactNewPosition != null)
                    {
                        artficat.position = artifactNewPosition.position;
                    }

                    foreach (GameObject wall in adjustenWalls)
                    {
                        wall.SetActive(!wall.activeSelf);

                    }


                }

                else
                {
                    if (artifactOldPosition != null)
                    {
                        artficat.position = artifactOldPosition.position;

                    }

                    foreach (GameObject wall in adjustenWalls)
                    {
                        wall.SetActive(!wall.activeSelf);

                    }


                }
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (reset == true)
            {
                foreach (GameObject wall in adjustenWalls)
                {
                    wall.SetActive(true);

                }
                player.gameObject.SetActive(false);
                player.gameObject.transform.position = restPos.position;
                player.gameObject.transform.rotation = restPos.rotation;

                player.gameObject.SetActive(true);
                artficat.position = artifactNewPosition.position;

            }

        }

    }

}


