
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private MovementType movementType;
    /*[SerializeField] private float rotationSpeed = 180f;*/
    [SerializeField] private float jumpForce = 5f;
    
    
    private Vector3 moveBy;
    private bool isMoving;
    private bool isJumpingOrFalling;
    private bool isColliding;
    private float initialJumpForce;

    // Start is called before the first frame update

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
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
            GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
               
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
         }
    
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

    public void Update()
    {
        /*print(isColliding);
        print(jumpForce);*/
        ExecuteMovement();
    }

    public void ExecuteMovement()
    {
        isJumpingOrFalling = GetComponent<Rigidbody>().velocity.y < -0.035f ||
                             GetComponent<Rigidbody>().velocity.y > 0.00001f;

        if (moveBy == Vector3.zero)
            isMoving = false;
        else
            isMoving = true;

        if (!isMoving)
        {
            return;
        }

        if (movementType == MovementType.TransformBased)
        {
            /*RotatePlayerFigure(moveBy.normalized);*/


            Vector3 forwardMovement = transform.forward * moveBy.z;
            //player not moving in relative z
            Vector3 sideMovement = transform.right * moveBy.x;
            Vector3 movement = (forwardMovement + sideMovement) * speed * Time.deltaTime;
            
            transform.Translate(movement, Space.World);
        }

    }


    
}

