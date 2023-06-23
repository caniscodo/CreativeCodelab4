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
    
   public static PortalOpener instance;



   private void Start()
    {
        instance = this;
    }
   
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            IsStandingInPortal = true;

        if (GlobalData.instance.allFishOfLevelCollected)
        {
            portalIsOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            IsStandingInPortal = false;

        if (portalIsOpen = true)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        print(IsStandingInPortal);
        
        if (IsStandingInPortal)
        {
            portalIsOpen = true;
        }
    }
}
