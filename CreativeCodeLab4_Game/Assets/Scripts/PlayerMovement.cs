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
    [SerializeField] private float rotationSpeed = 180f;

    

    private Vector3 moveBy;
    private bool isMoving;
    private bool isJumpingOrFalling;

    // Start is called before the first frame update

    void Start()
    {
    }

    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump(InputValue input)
    {
        if (isJumpingOrFalling)
            return;
        GetComponent<Rigidbody>().AddForce(0, 8, 0, ForceMode.VelocityChange);
    }

    void Update()
    {
        ExecuteMovement();
    }

    void ExecuteMovement()
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
            RotatePlayerFigure(moveBy.normalized);
            Vector3 movement = moveBy * speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }
        else if (movementType == MovementType.PhysicsBased)
        {
            // Remove physics-based movement code
        }
    }

    private void RotatePlayerFigure(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    
}
