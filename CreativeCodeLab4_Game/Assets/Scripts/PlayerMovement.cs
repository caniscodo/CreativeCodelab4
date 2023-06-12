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
        isJumpingOrFalling = GetComponent<Rigidbody>().velocity.y < -.035 ||
                             GetComponent<Rigidbody>().velocity.y > 0.00001;

        if (moveBy == Vector3.zero)
            isMoving = false;
        else
            isMoving = true;


        if (!isMoving)
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.z, 0);
            return;
        }

        if (movementType == MovementType.TransformBased)
        { RotatePlayerFigure(moveBy);
            
            //transform.position += moveBy * (speed * Time.deltaTime);
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        else if (movementType == MovementType.PhysicsBased)
        {
            var rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.AddForce(moveBy * 2, ForceMode.Acceleration);
        }
    }
    
    private void RotatePlayerFigure(Vector3 rotateVector)
    {
        rotateVector = Vector3.Normalize(rotateVector); //insure that only a directional value on gamepad
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.z, 0);
        var rotationY = 90 * rotateVector.x;    
        
        if (rotateVector.z < 0)
        {
            transform.Rotate(0, 180, 0);
            rotationY *= -1;
        }
        
        transform.Rotate(0, rotationY, 0);

    
    }
    
}