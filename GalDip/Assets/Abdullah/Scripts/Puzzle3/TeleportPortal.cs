using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportPortal : MonoBehaviour
{
    static public int countLoops = 0;
    public bool isReversed= false;
    public Transform playerNewPos;
    float  maxBend,maxStartDistance=0;
    public UnityEvent TeleportEvent;
    public WorldBendDriver worldBendDriver;

    // Start is called before the first frame update
    void Awake()
    {
        worldBendDriver = FindAnyObjectByType<WorldBendDriver>();

    }
    public void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.E))
        {
            AffectWorld();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isReversed ^= true;
        }
        */
    }
    public void Teleport()
    {
        TeleportEvent.Invoke();

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            other.gameObject.SetActive(false);
            other.transform.position = playerNewPos.position;
            other.gameObject.SetActive(true);
            worldBendDriver.AffectWorld(isReversed);
            Teleport();

        }
    }

}
