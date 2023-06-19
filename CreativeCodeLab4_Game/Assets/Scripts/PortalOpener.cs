using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Update = UnityEngine.PlayerLoop.Update;

public class PortalOpener : MonoBehaviour
{
    public bool IsStandingInPortal { get; private set; }
    public bool portalIsOpen { get; private set; }
    
    Collider collider;
    
   public static PortalOpener instance;

   private void Start()
   {
    
   }


   private void Awake()
    {
        if (instance == null)
        {
            instance = this;
          
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
       
        }
    }
   
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            IsStandingInPortal = true;

        if (GlobalData.instance.allFishOfLevelCollected)
        {
            collider = gameObject.GetComponent<Collider>();
            collider.isTrigger = true;
            portalIsOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            IsStandingInPortal = false;
    }

    private void Update()
    {
        print(IsStandingInPortal);
        
        if (GlobalData.instance.allFishOfLevelCollected && IsStandingInPortal)
        {
            collider = gameObject.GetComponent<Collider>();
            collider.isTrigger = true;
            portalIsOpen = true;
        }
    }
}
