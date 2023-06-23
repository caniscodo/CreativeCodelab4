using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (GlobalData.instance.allFishOfLevelCollected)
            {
                MenuManager.instance.Success();
            }
        }
    }
}
