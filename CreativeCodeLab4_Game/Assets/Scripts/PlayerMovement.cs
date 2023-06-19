
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private MovementType movementType;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    
    /*[SerializeField] private float rotationSpeed = 180f;*/
    [SerializeField] private float jumpForce = 5f;
    
    
    private Vector3 moveBy;
    private bool isMoving;
    private bool isJumpingOrFalling;
    private bool isColliding;
    private float initialJumpForce;

    // Start is called before the first frame update
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        initialJumpForce = jumpForce;
    }
    

    public void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump(InputValue input)
    {
        if (isColliding)
        {
            rb.AddForce(Vector3.up * initialJumpForce, ForceMode.VelocityChange);
        }
        else
        {
            if (jumpForce >= 1)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                jumpForce--;
            }
            else if (jumpForce <= 1)
            {
                rb.AddForce(Vector3.up * 0, ForceMode.VelocityChange);
               
            }
        }
    }
    /*if (isColliding)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
    else if(!isColliding) 
    {
        if (jumpForce >= 1)
        {
           GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.VelocityChange); 
           jumpForce--; 
           
        } else if (jumpForce <= 1)
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 0, ForceMode.VelocityChange);
        }
        
        }
     }*/
    
    void OnLook(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();
        transform.Rotate(0, inputValue.x, 0);

    }

    public void OnCollisionEnter(Collision other)
    {
        jumpForce = initialJumpForce;
        isColliding = true;
    }

    public void OnCollisionExit(Collision other)
    {
        isColliding = false;
    }

    public void FixedUpdate()
    {
        /*print(isColliding);
        print(jumpForce);*/
        ExecuteMovement();
    }

    public void ExecuteMovement()
    {
        if (moveBy == Vector3.zero)
        {
           
            rb.velocity = Vector3.zero;
            return;
        }
       
        Vector3 moveDirection = new Vector3(moveBy.x, 0f, moveBy.y);
        moveDirection = Quaternion.Euler(0f, virtualCamera.transform.eulerAngles.y, 0f) * moveDirection;

     
        Vector3 movement = moveDirection.normalized * speed;
        movement += transform.forward * moveBy.magnitude * speed;

  
        rb.AddForce(movement, ForceMode.VelocityChange);
        
        
        
        /*//DONT
        if (movementType == MovementType.TransformBased)
        {
            Vector3 forwardMovement = transform.forward * moveBy.z;
            //player not moving in relative z
            Vector3 sideMovement = transform.right * moveBy.x;
            Vector3 movement = (forwardMovement + sideMovement) * speed * Time.deltaTime;

            transform.Translate(movement, Space.World);
        }*/
        /*else if (movementType == MovementType.PhysicsBased)
        {
            Vector3 movement = new Vector3(moveBy.x, 0f, moveBy.y);
            rb.AddForce(movement.normalized * speed, ForceMode.VelocityChange);
        }*/

    }


    
}

