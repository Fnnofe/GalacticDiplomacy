using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float rotationSpeedX = 100f;
    [SerializeField] private float rotationSpeedY = 100f;
    private float activeSpeed;
    private Camera cam;
    private Transform yRotPoint;
    private Vector3 moveDir, movement;
    float yRot = 0f;
    private CharacterController controller;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
        yRotPoint = transform.GetChild(2);
    }
    
    void Update()
    {
        MovePlayer();
        PlayerTurning();
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
        if (Input.GetKey(KeyCode.LeftShift))  activeSpeed = runSpeed;
        else activeSpeed = movementSpeed;
        float yVel = movement.y;
        movement = (transform.forward * moveDir.z) + (transform.right * moveDir.x);
        movement.y = yVel;
        if (controller.isGrounded)
        {
            movement.y = 0f;
        }
        movement.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);
        
    }

    void PlayerTurning()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * rotationSpeedX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * rotationSpeedY * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y + mouseX, 0);
        yRot -= mouseY;
        yRot = Mathf.Clamp(yRot, -60f, 60f);
        yRotPoint.rotation = Quaternion.Euler(yRot, transform.rotation.eulerAngles.y , 0);
    }
}
