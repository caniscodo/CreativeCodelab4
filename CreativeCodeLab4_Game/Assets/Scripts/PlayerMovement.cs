
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float sensitivity;
    public float maxForce;
    public float jumpForce;
    private float lookRotation;
    
    public bool grounded;
    
    private Vector2 look;
    private Vector2 movement;
    

    public CinemachineVirtualCamera VirtualCamera;
    public Rigidbody rb;


    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }   
    
    
    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }
    

    public void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        VirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
      Move();
      
    }

    private void Move()
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(movement.x, 0, movement.y);
        targetVelocity *= speed;

        targetVelocity = transform.TransformDirection((targetVelocity));

        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);
        
        Vector3.ClampMagnitude(velocityChange, maxForce);
        
        
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void Look()
    {
        lookRotation += (-look.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        VirtualCamera.transform.eulerAngles = new Vector3(lookRotation, VirtualCamera.transform.eulerAngles.y,
            VirtualCamera.transform.eulerAngles.z);
    }

    private void Jump()
    {
        Vector3 jumpForces = Vector3.zero;

        if (grounded)
        {
            jumpForces = Vector3.up * jumpForce;
            rb.AddForce(jumpForces, ForceMode.VelocityChange);
        }
    }

    private void LateUpdate()
    {
        //Turn
       transform.Rotate(Vector3.up *look.x * sensitivity);

    Look();

    }

    public void setGrounded(bool state)
    {
        grounded = state;
    }
    
}

