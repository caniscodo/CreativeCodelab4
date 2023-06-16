using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBubble : MonoBehaviour
{
    private float airTime;

    private bool playerInBubble;
    // Start is called before the first frame update
    void Start()
    {
        playerInBubble = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        /*AirManager.instance.startTimerForAir(airTime);*/
      
        
    }

    private void OnTriggerStay(Collider other)
    {
        playerInBubble = true;
        airTime += Time.deltaTime;
        
        if (airTime == 3)
        {
            AirManager.instance.increaseAirAmount();
            print($"airtime increased {airTime}");
           
        }

      
      
    }

    private void OnTriggerExit(Collider other)
    {
        airTime = 0;
       
    }
}
