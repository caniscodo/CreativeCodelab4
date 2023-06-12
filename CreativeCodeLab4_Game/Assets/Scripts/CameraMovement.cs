/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private GameObject playerObject;
    [SerializeField] private float closestDistanceToPlayer;
    [SerializeField] private float maximumAngle;

    private float maximumDistanceFromPlayer;
    private Vector3 previousPlayerPostion;

    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        previousPlayerPostion = playerObject.transform.position;
        maximumDistanceFromPlayer = Vector3.Distance(transform.position, previousPlayerPostion);
        maximumDistanceFromPlayer = Mathf.Abs(maximumDistanceFromPlayer);
        playerTransform = playerObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        var currentPlayerPosition = playerObject.transform.position;
        var deltaPlayerPosition = currentPlayerPosition - previousPlayerPostion;
        transform.position += deltaPlayerPosition;
        previousPlayerPostion = currentPlayerPosition;
    }

    void OnCameraMovement(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        CameraRotationYAxis(inputVector);
        CameraRotationXAxis(inputVector);
    }
    

    void CameraRotationYAxis(Vector2 inputVector)
    {
        this.transform.RotateAround(playerTransform.position, new Vector3(0,1,0),  inputVector.x);
    }
    
    void CameraRotationXAxis(Vector2 inputVector)
    {
        var upValue = inputVector.y * 0.2f;
        var originalPosition = transform.position;
        var originalRotation = transform.rotation;
        this.transform.RotateAround(playerTransform.position, transform.right,  upValue);

        if (Vector3.Angle(playerTransform.forward, transform.forward) > maximumAngle)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }
    
    
}*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public GameObject followTransform;
    
    public float rotationPower = 3f;
    public Vector2 _look;
    public void OnLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }
    private void Update()
    {
        followTransform.transform.rotation *= Quaternion.AngleAxis(_look.y * rotationPower, Vector3.right);

        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTransform.transform.localEulerAngles.x;

        //Clamp the Up/Down rotation
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if(angle < 180 && angle > 40)
        {
            angles.x = 40;
        }


        followTransform.transform.localEulerAngles = angles;
        
        //Set the player rotation based on the look transform
        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
        //reset the y rotation of the look transform
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
    }
}