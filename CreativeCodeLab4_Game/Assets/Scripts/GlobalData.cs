using System.Collections;
using System.Collections.Generic;
using TMPro;
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
 
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI textMeshProGold;
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        textMeshPro.text = collectedFish.ToString();
        textMeshProGold.text = collectedGoldenFish.ToString();

        if (collectedFish >= 1)
        {
            allFishOfLevelCollected = true;
            print("all blue fish collected!");
        }
        else
        {
            print("You are missing some fish");
        }
        
        if (GameObject.FindGameObjectsWithTag("Fish").Length == 0)
        {
            allFishOfLevelCollected = true;
            print("No more Collectible objects in the scene. Setting allFishOfLevelCollected to true.");
        }
    }


    public void IncreaseHealth(int increaseBy)
    {

        if (playerHealth <= 4)
        {
            playerHealth += increaseBy;
            HealthDisplay.instance.UpdateHealthDisplay(playerHealth);
        }

        if (playerHealth <= 0)
        {
            print("Oi mate, u used all u health");
            MenuManager.instance.GameOver();
        }
    }

    public void decreaseHealth(int decreaseBy)
    {
        if (playerHealth >= 1)
        {
                   playerHealth-= decreaseBy;
                    HealthDisplay.instance.UpdateHealthDisplay(playerHealth);
        }
     
        
        if (playerHealth <= 0)
        {
            print("no health left");
            MenuManager.instance.GameOver();
        }

        
      

    }

    public void collectFish(int increaseFishBy)
    {

            collectedFish += increaseFishBy;
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
