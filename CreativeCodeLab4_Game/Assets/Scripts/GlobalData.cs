using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static GlobalData instance;

    public int playerHealth;
    

    public int initialHealth = 5;
    // Start is called before the first frame update
    
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    void Start()
    {
        playerHealth = initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseHealth(int increaseBy)
    {
        // Assuming you have a reference to the HealthManager GameObject
        

        playerHealth += increaseBy;
        HealthDisplay.instance.UpdateHealthDisplay(playerHealth);
    }

    public void decreaseHealth(int decreaseBy)
    {

        HealthDisplay.instance.UpdateHealthDisplay(playerHealth);
        playerHealth -= decreaseBy;

    }
    
    
}
