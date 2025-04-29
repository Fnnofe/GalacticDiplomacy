using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


	public class Door : MonoBehaviour, IInteractable
	{
        public int ArtifactNeeded;

        public bool open;
        public bool stayOpen = false;
        public bool reverseMotion;
        public GameObject door;
        public GameObject frameCollider;
        GameProgression arifactCollected;

        public float smooth = 1.0f;
		float DoorOpenAngle = -90.0f;
		float DoorCloseAngle = 0.0f;
		public AudioSource asource;
		public AudioClip openDoor, closeDoor,lockedDoor;
        //public GameObject openDoorUI;

		// Use this for initialization
		void Start()
		{
            arifactCollected= FindAnyObjectByType<GameProgression>();
            asource = GetComponent<AudioSource>();
            // openDoorUI.SetActive(false);
            if (reverseMotion)
            {
                DoorOpenAngle = 90f;
            }
        }

        // Update is called once per frame
        void Update()
		{
                if (open == false)
                {
                    var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                    door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, target1, Time.deltaTime * 5 * smooth);

                }
                else
                {
                    var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                    door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, target, Time.deltaTime * 5 * smooth);
                }


        }

		public void OpenDoor()
		{
			open = !open;
			asource.clip = open ? openDoor : closeDoor;
			asource.Play();
		}

		public void StayOpen()
		{
			stayOpen = true;

        }



        public void Interact()
        {
            if (ArtifactNeeded <= arifactCollected.collocetedArtifact)
            {

                if (open && stayOpen == false)
                {
                    frameCollider.GetComponent<BoxCollider>().enabled = true;
                    Debug.Log("CLOSED");
                    OpenDoor();
                }
                else if (stayOpen == true)
                {
                    frameCollider.GetComponent<BoxCollider>().enabled = false;
                    open = true;
                }
                else
                {
                    frameCollider.GetComponent<BoxCollider>().enabled = false;
                    Debug.Log("OPEN");
                    OpenDoor();
                }
            }
            else
            {

                asource.clip = lockedDoor;
                asource.Play();

            }

        }


        public void Observe()
        {
            InteractbleDialouge.Instance.ShowText("interact with Door");
        }
    }

}