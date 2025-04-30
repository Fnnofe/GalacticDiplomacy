using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class EndCutsceneTrigger : MonoBehaviour
{
   [SerializeField] private PlayableDirector cutscene;
   void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         cutscene.Play();
      }
   }
}
