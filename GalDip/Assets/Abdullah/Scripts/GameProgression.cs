using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameProgression : MonoBehaviour
{
    public GameObject artifcatUI;
    public int collocetedArtifact;
    [SerializeField] AudioSource audioSource;

    public void CollectedArtifact()
    {
        artifcatUI.SetActive(true);
        collocetedArtifact++;
        artifcatUI.GetComponent<TextMeshProUGUI>().text = ("0" + collocetedArtifact);
        audioSource.Play();



    }
   

}
