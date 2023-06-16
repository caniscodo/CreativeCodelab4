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

    private void increaseAirAmount()
    {
        if (AirAmount <= 2)
        {
            AirAmount++;
        }
        
        
    }
}
