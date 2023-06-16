using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static GlobalData instance;

    public int playerHealth;
    public int initialHealth = 5;

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
    
    
}
