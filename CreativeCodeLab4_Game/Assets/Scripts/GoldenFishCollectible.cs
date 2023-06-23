using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenFishCollectible : MonoBehaviour
{   
    private bool collected = false;
    private bool canCollide = true;


    private void OnTriggerEnter(Collider collider)
    {
        if (!canCollide || collected)
            return;

        if (collider.CompareTag("Player"))
        {
            print("golden fish storage increases");
            GlobalData.instance.collectGoldenFish(1);
            Destroy(this.gameObject);

            collected = true;
            canCollide = false;
            
            GameObject healthCollectible = this.gameObject;
            AkGameObj akGameObj = healthCollectible.GetComponent<AkGameObj>();
            if (akGameObj != null)
            {
                // Trigger the sound event on the player object
                AkSoundEngine.PostEvent("Play_collectGoldenFish", akGameObj.gameObject);
            }
        }
    }
    
    
    private void OnTriggerExit(Collider collider)
    {
        collected = false;
    }
}
