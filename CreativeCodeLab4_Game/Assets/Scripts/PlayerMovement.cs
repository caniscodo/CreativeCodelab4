
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
    public float spiderEffectDuration;

    private int jumpCount = 0;
    
    public bool grounded;
    public bool canJump;
    public bool isJumping;
    public bool isShooting;
    private bool jumpUp;
    
    private Vector2 look;
    public Vector2 movement;
    private Animator animator;
    public ParticleSystem ps;

    public static PlayerMovement instance;


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
        
        if (context.performed)
        {
            isShooting = true;
            var em = ps.emission;
            em.enabled = true;
            
            Shoot();
            
            print($"playerShooting is {isShooting}");
        }
        else if (context.canceled)
        {
            isShooting = false;
            var em = ps.emission;
            em.enabled = false;
        }
    }   
    
    
    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
        isJumping = true;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }


    public void Start()
    {
        
        rb = this.GetComponent<Rigidbody>();

        animator = GetComponentInChildren<Animator>();
        ps  = GetComponentInChildren<ParticleSystem>();
        var em = ps.isEmitting;
        em = false;
        
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
        
        
        if (movement.magnitude <= 0)
        {
            print("idle should be playing");
            animator.SetFloat("Speed", 0, 0.01f, Time.deltaTime);
        }

        else
        {
            print("walk should be playing");
            animator.SetFloat("Speed", 0.9f, 0.01f, Time.deltaTime);
        }

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
        lookRotation = Mathf.Clamp(lookRotation, -140, 90);

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

        if (jumpForces.magnitude > 0)
        {
            animator.SetTrigger("JumpUp");
            jumpUp = true;
        } else if (jumpUp)
        {
            animator.SetTrigger("JumpDown");
        }
        if (grounded)
        {
            jumpCount = 0; 
            jumpForce = initialJumpForce; 
        }
    }

    private void Shoot()
    {
        var em = ps.isEmitting;
        em = true;
        animator.SetTrigger(("Shoot"));
        print("playerShootingInMovement");
    }

    private void LateUpdate()
    {
        transform.Rotate(Vector3.up * look.x * sensitivity);

        if (!isShooting)
        {
            var em = ps.emission;
            em.enabled = false;
        }

        Look();

    }

    public void setGrounded(bool state)
    {
        print("in set grounded");
        grounded = state;
        canJump = true;
    }
    

    public void spiderEffect()
    {  
        /*spiderEffectDuration = 2;*/

        /*for (int i = 0; i < spiderEffectDuration * Time.deltaTime; i++)*/
            GlobalData.instance.decreaseHealth(1);
    }
    
}

