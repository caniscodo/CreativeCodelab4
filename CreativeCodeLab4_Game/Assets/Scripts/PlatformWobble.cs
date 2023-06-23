using System;
using UnityEngine;

public class PlatformWobble : MonoBehaviour
{
    void Start()
    {
        initialPosition = transform.position;
    }

    private Vector3 initialPosition;

   public float weight = 1.0f;
   
    private float totalWeight = 0.0f;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody platformRigidbody = GetComponent<Rigidbody>();

          
            Vector3 playerPosition = collision.gameObject.transform.position;
            Vector3 platformPosition = transform.position;
            float side = Mathf.Sign(playerPosition.x - platformPosition.x);

           
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            float playerMass = playerRigidbody.mass;
            float playerWeight = playerMass * weight;

            totalWeight += playerWeight * side;

            platformRigidbody.AddTorque(Vector3.up * totalWeight, ForceMode.Force);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            initialPosition = transform.position;
        }
    }
}
