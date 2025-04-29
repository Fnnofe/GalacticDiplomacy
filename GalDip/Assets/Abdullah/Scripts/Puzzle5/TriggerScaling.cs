using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScaling : MonoBehaviour
{
    public RescalePlayer rescalePlayer;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            rescalePlayer.enabled = !rescalePlayer.enabled;

        }
    }

}
