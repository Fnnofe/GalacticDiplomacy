using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource footstepSound;
    private float footstepDelay;
    private float footstepTimer;
    
    [Header("Footstep Clips")]
    [SerializeField] private AudioClip[] woodSteps;
    [SerializeField] private AudioClip[] carpetSteps;
    
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float rotationSpeedX = 100f;
    [SerializeField] private float rotationSpeedY = 100f;
    
    private float activeSpeed;
    private Camera cam;
    private Transform yRotPoint;
    private Vector3 moveDir, movement;
    float yRot = 0f;
    private CharacterController controller;
    private InspectObject inspectObject;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // This will not make the object rotate.
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
        yRotPoint = transform.GetChild(2);
    }
    
    void Update()
    {
        inspectObject = FindObjectOfType<InspectObject>();
        if (inspectObject == null)
        {
            MovePlayer();
            PlayerTurning();
            Cursor.lockState = CursorLockMode.Locked;
           // Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void LateUpdate()
    {
        cam.transform.position = yRotPoint.position;
        cam.transform.rotation = yRotPoint.rotation;
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(horizontal, 0, vertical).normalized * activeSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            activeSpeed = runSpeed;
            footstepDelay = 0.3f;
        }
        else
        {
            activeSpeed = movementSpeed;
            footstepDelay = 0.5f;
        }
        float yVel = movement.y;
        movement = (transform.forward * moveDir.z) + (transform.right * moveDir.x);
        movement.y = yVel;
        if (controller.isGrounded)
        {
            movement.y = 0f;
            if (moveDir.magnitude > 0.1f)
            {
                footstepTimer -= Time.deltaTime;
                if (footstepTimer <= 0f)
                {
                    PlayFootstepSound();
                    footstepTimer = footstepDelay;
                }
            }
            else
            {
                footstepTimer = 0f; // Reset timer when not moving
            }
        }
        movement.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);
        
    }
    void PlayFootstepSound()
    {
        int layerMask = ~LayerMask.GetMask("Player");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f, layerMask))
        {
            string tag = hit.collider.tag;
            AudioClip[] selectedClips = null;

            switch (tag)
            {
                case "MBS:Floor":
                    selectedClips = woodSteps;
                    break;
                case "Carpet":
                    selectedClips = carpetSteps;
                    break;
            }

            if (selectedClips != null && selectedClips.Length > 0)
            {
                AudioClip clip = selectedClips[Random.Range(0, selectedClips.Length)];
                footstepSound.PlayOneShot(clip);
            }
        }
    }

    void PlayerTurning()
    {
        if (FindObjectOfType<InspectObject>() != null) return;
        float mouseX = Input.GetAxisRaw("Mouse X") * rotationSpeedX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * rotationSpeedY * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y + mouseX, 0);
        yRot -= mouseY;
        yRot = Mathf.Clamp(yRot, -60f, 60f);
        yRotPoint.rotation = Quaternion.Euler(yRot, transform.rotation.eulerAngles.y , 0);
    }
}
