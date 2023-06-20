
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
    public float initialJumpForce;
    private float lookRotation;
    
    private int jumpCount = 0;
    
    public bool grounded;
    public bool canJump;
    public bool isJumping;
    public bool isShooting;
    
    private Vector2 look;
    public Vector2 movement;
   


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
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        isShooting = true;
        Shoot();
       
    }   
    
    
    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
        isJumping = true;
    }
    

    public void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        
        VirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        Cursor.lockState = CursorLockMode.Locked;
        isJumping = false;
        initialJumpForce = jumpForce;
    }

    private void FixedUpdate()
    {
        print(grounded);
        Move();
       setGrounded(grounded);
     
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

        if (grounded && canJump && jumpCount < 5)
        {
            jumpForces = Vector3.up * jumpForce;
            rb.AddForce(jumpForces, ForceMode.VelocityChange);
            canJump = false;
            jumpCount++;
            jumpForce--;
        }
        else if (AirManager.instance.airAmount >= 1)
        {
            jumpForces = Vector3.up * 30f;
            rb.AddForce(jumpForces, ForceMode.VelocityChange);
            AirManager.instance.airAmount--;
            jumpForce = initialJumpForce;
        }

        if (grounded)
        {
            jumpCount = 0; 
            jumpForce = initialJumpForce; 
        }
    }

    private void Shoot()
    {
        print("playerShootingInMovement");
    }

    private void LateUpdate()
    {
        //Turn
       transform.Rotate(Vector3.up *look.x * sensitivity);

        Look();

    }

    public void setGrounded(bool state)
    {
        print("in set grounded");
        grounded = state;
        canJump = true;
    }
    
}

