using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirManager : MonoBehaviour
{
    [SerializeField] private Image[] airImages;

    public static AirManager instance;

    public int airAmount;
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

        airAmount = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        UpdateAirDisplay(airAmount);
    }

   

    public void increaseAirAmount(int increasedAmount)
    {
       
        if (airAmount <= 2)
        {
            airAmount += increasedAmount;
            print($"AirAmount increased to {airAmount}");
            UpdateAirDisplay(airAmount);
            
        }
        
        
    }

    public void UpdateAirDisplay(int airAmount)
    {
        print("in update health");
        for (int i = 0; i < airImages.Length; i++)
        {
            if (i < airAmount)
                airImages[i].enabled = true;
            else
                airImages[i].enabled = false; 
        }
    
        
        for (int i = airAmount; i < airImages.Length; i++)
        {
            airImages[i].enabled = false;
        }
    }
}
