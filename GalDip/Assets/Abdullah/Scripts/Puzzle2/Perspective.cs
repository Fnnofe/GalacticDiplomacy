using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Perspective : MonoBehaviour
{
    public GameObject stareAtObject;
    public UnityEvent puzzleResult;
    Ray myRay;
    LayerMask myLayerMask= ~11;
    bool isCastingRay = false;
    float timer = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isCastingRay)
        {
            timer -= (1 * Time.deltaTime);
            if (timer < 0)
            {
                myRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 20);
                RaycastHit hit;
                Physics.Raycast(myRay, out hit, 60f, myLayerMask, QueryTriggerInteraction.Collide);
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward*20, Color.red, 1f);
                if (hit.collider != null)
                {
                    Debug.DrawLine(Camera.main.transform.position, hit.collider.transform.position,Color.green);

                    Debug.Log("hit: " + hit.collider.name);

                    if (hit.collider.name == stareAtObject.name)
                    {
                        //Solved Puzzle
                        Debug.Log("Puzzle2 Solved");
                        SolvePuzzled();
                    }
                    
                }

               timer = 0.3f;
            }
        }

    }

    public void SolvePuzzled()
    {
        puzzleResult.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isCastingRay = true;
        }
        Debug.Log("isCastingRay:" + isCastingRay);

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            isCastingRay = false;
        }
        Debug.Log("isCastingRay:" + isCastingRay);

    }

}