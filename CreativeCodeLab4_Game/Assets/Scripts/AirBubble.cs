using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBubble : MonoBehaviour
{
    private float airTime;
    private bool canStillIncrease;
    private bool playerInBubble;
    // Start is called before the first frame update
    void Start()
    {
        canStillIncrease = true;
        playerInBubble = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        canStillIncrease = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInBubble = true;
            airTime += Time.deltaTime;
        
            if (airTime >= 3 && canStillIncrease)
            {
                increaseAirAmount();
                Destroy(this.gameObject);
                canStillIncrease = false;
            }
        }
    }
    
    
    
    private void increaseAirAmount()
    {
        AirManager.instance.increaseAirAmount(1);
        print($"airtime increased {airTime}");
        canStillIncrease = false;
    }

    private void OnTriggerExit(Collider other)
    {
        airTime = 0;
    }
}
