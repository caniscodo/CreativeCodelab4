
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
    private Vector2 look;
    private Vector2 movement;
    private float lookRotation;

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
    

    public void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        VirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        
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

    private void LateUpdate()
    {
        //Turn
       transform.Rotate(Vector3.up *look.x * sensitivity);

       lookRotation += (-look.y * sensitivity);
       lookRotation = Mathf.Clamp(lookRotation, -90, 90);
       VirtualCamera.transform.eulerAngles = new Vector3(lookRotation, VirtualCamera.transform.eulerAngles.y,
           VirtualCamera.transform.eulerAngles.z);

    }


    /*
    [SerializeField] private float speed = 20f;
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
        
         virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

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


        /*moveDirection.Normalize();#1#


        Vector3 movement = moveDirection * speed * Time.deltaTime;
        movement += transform.forward * moveBy.magnitude * speed * Time.deltaTime;


        rb.AddForce(movement, ForceMode.VelocityChange);

    }
    */


    
}

