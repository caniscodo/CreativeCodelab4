using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Image[] healthImages;
    public static HealthDisplay instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    private void Start()
    {

        UpdateHealthDisplay(GlobalData.instance.initialHealth);
    }

    public void UpdateHealthDisplay(int health)
    {
        print("in update health");
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < health)
                healthImages[i].enabled = true;
            else
                healthImages[i].enabled = false; 
        }
    
        
        for (int i = health; i < healthImages.Length; i++)
        {
            healthImages[i].enabled = false;
        }
    }


}

