using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static GlobalData instance;

    public float playerHealth;
    

    public float initialHealth = 5;
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
        playerHealth += increaseBy;
    }

    public void decreaseHealth()
    {
        
    }
    
    
}
