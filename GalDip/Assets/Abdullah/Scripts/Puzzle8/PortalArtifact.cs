using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalArtifact : MonoBehaviour
{
    public Transform newPosition;
    public bool puzzleSolved=false;
    public Transform nextRoom;
    static float teleportCd =0.5f;
    public UnityEvent solvedPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportCd > 0) 
        { 
        
            teleportCd-=1*Time.deltaTime;
        
        }

    }
    private void OnTriggerStay(Collider artifact)
    {
        if(artifact.tag== "Artifact")
        {
            Debug.Log("FOUND:  "+artifact.name);
            if (teleportCd <= 0)
            {
                Debug.Log("Teleport Artifact");
                artifact.gameObject.SetActive(false);
                artifact.transform.position = newPosition.position;
                artifact.gameObject.SetActive(true);
                if (puzzleSolved)
                {
                    artifact.gameObject.SetActive(false);
                    artifact.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    solvedPuzzle.Invoke();
                }

                teleportCd = 0.5f;
            }


        }

    }

}
