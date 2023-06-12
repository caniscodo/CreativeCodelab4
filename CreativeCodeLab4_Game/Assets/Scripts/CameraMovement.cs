using System;
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
    
    
}