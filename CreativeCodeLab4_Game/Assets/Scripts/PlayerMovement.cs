
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    
    [SerializeField] private float jumpForce = 20f;
    
    
    private Vector3 moveBy;
    private bool isMoving;
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
        else if (jumpForce >= 1)
        { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpForce--; 
        } 
        else if (jumpForce <= 1)
        {
            rb.AddForce(Vector3.up * 0, ForceMode.VelocityChange);

        }
    }

    void OnLook(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();
        transform.Rotate(0, inputValue.x, 0);

    }

    public void OnCollisionEnter(Collision other)
    {
        print(other.gameObject);
        jumpForce = initialJumpForce;
        isColliding = true;
    }

    public void OnCollisionExit(Collision other)
    {
        isColliding = false;
    }

    public void FixedUpdate()
    {
        ExecuteMovement();
    }

    private void Update()
    {
       
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


        moveDirection.Normalize();


        Vector3 movement = moveDirection * speed * Time.deltaTime;
        movement += transform.forward * moveBy.magnitude * speed * Time.deltaTime;


        rb.AddForce(movement, ForceMode.VelocityChange);

    }


    
}

