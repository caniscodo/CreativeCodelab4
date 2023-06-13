using UnityEngine;

public class PlatformWobble : MonoBehaviour
{
    public float rotationSpeed = 0.5f;
    public float shiftDuration = 0.01f;
    private bool shouldRotate = false;
    private Vector3 initialPosition;
    private Quaternion initialRotation; //!!

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            shouldRotate = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            shouldRotate = false;
        }
        
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    void Update()
    {
        if (shouldRotate)
        {

            float rotationAxis = Input.GetAxis("Horizontal");
        
            float rotationAmount = rotationSpeed * rotationAxis * Time.deltaTime;
         
            transform.Rotate(Vector3.right, rotationAmount);
        }
    }


}