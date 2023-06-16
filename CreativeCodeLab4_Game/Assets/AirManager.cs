using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirManager : MonoBehaviour
{
    public static AirManager instance;

    public int AirAmount;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }

        AirAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void increaseAirAmount()
    {
       
        if (AirAmount <= 2)
        {
            AirAmount++;
            print($"AirAmount increased to {AirAmount}");
            
        }
        
        
    }

    /*public void startTimerForAir(int timeSpentInBubble)
    {
        if (timeSpentInBubble >= 3)
        {
            print($"SpentTimeInBubble = {AirAmount}");
            AirAmount++;
        }
    }*/
}
