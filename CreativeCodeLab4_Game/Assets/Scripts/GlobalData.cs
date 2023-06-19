using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static GlobalData instance;

    public int playerHealth;
    public int initialHealth = 5;
    //---
    public int collectedFish { get; private set; }
    public int collectedGoldenFish { get; private set; }
    
    public bool allFishOfLevelCollected { get; private set; }
    public bool allGoldenFishOfLevelCollected { get; private set; }
    //--
 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Preserve the instance across scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        playerHealth = initialHealth;
        allFishOfLevelCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHealth(int increaseBy)
    {

        if (playerHealth <= 4)
        {
            playerHealth += increaseBy;
        } 

        HealthDisplay.instance.UpdateHealthDisplay(playerHealth);
    }

    public void decreaseHealth(int decreaseBy)
    {
        playerHealth -= decreaseBy;
        HealthDisplay.instance.UpdateHealthDisplay(playerHealth);
      

    }

    public void collectFish(int increaseFishBy)
    {
        if (collectedFish >= 1)
        {
            allFishOfLevelCollected = true;
            print("all blue fish collected!");
        }
        else
        {
            collectedFish += increaseFishBy;
        }
    }

    public void collectGoldenFish(int increaseGoldenFishBy)
    {
        if (collectedGoldenFish >= 2)
        {
            allGoldenFishOfLevelCollected = true;
            print("all golden special fish collected!");
        }
        else
        {
            collectedGoldenFish += increaseGoldenFishBy;
        }
    }
    
    
    
}
