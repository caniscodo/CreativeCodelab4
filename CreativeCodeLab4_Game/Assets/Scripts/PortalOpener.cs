using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOpener : MonoBehaviour
{
    public bool IsStandingInPortal { get; private set; }
    public bool portalIsOpen { get; private set; }
    
   public static PortalOpener instance;
   
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
        
        /*if(GameStats.instance.collectedFish )*/
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            IsStandingInPortal = false;
    }

    private void Update()
    {
        print(IsStandingInPortal);
    }
}
