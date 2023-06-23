using System;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float duration = 20f;
    public float rotationSpeed = 90f; // Adjust the rotation speed as desired
    public GameObject RocketObject;
    public float delayBetweenRockets = 10f; // Adjust the delay as desired
    private bool canInstantiate = true;

    private float t = 0f;

    private void Start()
    {
        InstantiateRocket();
    }

    private void Update()
    {
        t += Time.deltaTime / duration;

        if (t > 1f)
        {
            t = 1f;
        }

        Vector3 position = Vector3.Lerp(startPoint.position, endPoint.position, t);
        transform.position = position;

        // Apply rotation
        float rotationAngle = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAngle);

        DestroyAfterArrival();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("rocket hit player");
            GlobalData.instance.decreaseHealth(1);
            DestroyRocket();
        }
    }

    private void DestroyAfterArrival()
    {
        if (transform.position == endPoint.position)
        {
            print("Rocket ended");
            DestroyRocket();
        }
    }

    private void DestroyRocket()
    {
        Destroy(gameObject);

        // Instantiate a new rocket after a delay
        if (canInstantiate)
        {
            Invoke("InstantiateRocket", delayBetweenRockets);
            canInstantiate = false;
        }
    }

    private void InstantiateRocket()
    {
        Instantiate(RocketObject, startPoint.position, startPoint.rotation);
        canInstantiate = true;
    }
}