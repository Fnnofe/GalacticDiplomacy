using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


	public class Door : MonoBehaviour
	{
		public bool open;
        public bool stayOpen = false;

        public GameObject door;
        public GameObject frameCollider;
        
        bool canOpen =false;
        
        public float smooth = 1.0f;
		float DoorOpenAngle = -90.0f;
		float DoorCloseAngle = 0.0f;
		public AudioSource asource;
		public AudioClip openDoor, closeDoor;
		// Use this for initialization
		void Start()
		{
			asource = GetComponent<AudioSource>();
		}

		// Update is called once per frame
		void Update()
		{
			if(open == false)
			{
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, target1, Time.deltaTime * 5 * smooth);

            }
			else
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, target, Time.deltaTime * 5 * smooth);
            }
            if (canOpen)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (open && stayOpen==false)
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

        private void OnTriggerEnter(Collider other)
        {
			if (other.tag == "Player")
			{
				canOpen = true;
            }


        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                canOpen = false;
            }


        }


    }

}