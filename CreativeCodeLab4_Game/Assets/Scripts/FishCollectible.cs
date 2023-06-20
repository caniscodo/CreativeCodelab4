using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollectible : MonoBehaviour
{
    private bool collected = false;


    private void OnTriggerEnter(Collider collider)
    {
        if (collected)
            return;

        if (collider.CompareTag("Player"))
        {
            print("fish storage increases");
            GlobalData.instance.collectFish(1);
            Destroy(this.gameObject);

            collected = true;

        }
    }


    
    private void OnTriggerExit(Collider collider)
    {
        collected = false;
       
            
    }
}
