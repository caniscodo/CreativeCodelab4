using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private bool collected = false;
    private float collisionCooldown = 1.0f;  // Set the desired cooldown time here
    private bool canCollide = true;

    private IEnumerator ResetCollisionCooldown()
    {
        canCollide = true;
        yield return new WaitForSeconds(collisionCooldown);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!canCollide || collected)
            return;

        if (collider.CompareTag("Player"))
        {
            print("collectible increases");
            GlobalData.instance.IncreaseHealth(1);
            Destroy(this.gameObject);

            collected = true;
            canCollide = false;
            StartCoroutine(ResetCollisionCooldown());
        }
    }


    
    private void OnTriggerExit(Collider collider)
    {
        collected = false;
       
            
    }
}