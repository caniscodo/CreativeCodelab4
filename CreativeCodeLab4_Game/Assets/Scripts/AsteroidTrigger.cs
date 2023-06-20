using System;
using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    public GameObject asteroid;
    public string playerTag = "Player";
    public float moveSpeed = 0.1f;
    public bool playerTriggeredAsteroid;
    private Transform playerTransform;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(playerTag))
        {
            playerTriggeredAsteroid = true;
            print("player triggered asteroid");
           
        }
    }

    private void Update()
    {
        MoveAsteroidTowardsPlayer();
    }

    private void MoveAsteroidTowardsPlayer()
    {
        if (playerTriggeredAsteroid)
        {
               playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
                    Vector3 targetPosition = playerTransform.position;
                    Vector3 currentPosition = asteroid.transform.position;
            
                    print("is in movment of asteroid");
                    
                    asteroid.transform.position = Vector3.Lerp(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
                    
                    print(asteroid.transform.position);
        }

    }
}