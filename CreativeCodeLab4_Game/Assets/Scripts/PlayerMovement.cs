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
    [SerializeField] private float speed = 8f;
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
        print("onMovement is called");
        Vector2 inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump(InputValue input) 
    {
        print("on Jump is called");
        if (isJumpingOrFalling)
            return;
        GetComponent<Rigidbody>().AddForce(0, 8, 0, ForceMode.VelocityChange);
    }

    /*void Update()
    {
        ExecuteMovement();
    }
    */

    /*void ExecuteMovement()
    {
        isJumpingOrFalling = GetComponent<Rigidbody>().velocity.y < -.035 ||
                             GetComponent<Rigidbody>().velocity.y > 0.00001;

        if (moveBy == Vector3.zero)
            isMoving = false;
        else
            isMoving = true;
        

        if (!isMoving)
        {
            print("not moving");
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.z, 0);
            return;
        }

        if (movementType == MovementType.TransformBased)
        {
            print("is being transformed");
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        else if (movementType == MovementType.PhysicsBased)
        {
            var rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.AddForce(moveBy * 2, ForceMode.Acceleration);
        }
    }*/

   
}