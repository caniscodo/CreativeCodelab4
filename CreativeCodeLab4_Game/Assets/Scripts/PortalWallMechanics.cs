using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalWallMechanics : MonoBehaviour
{
    public static PortalWallMechanics instance;

    public bool portalIsOpen;

  

    private void Awake()
    {
        instance = this;
        
    }

    private void LateUpdate()
    { 
        portalIsOpen = PortalOpener.instance.portalIsOpen;
        print($" Portal is open in Wall is {portalIsOpen}");
        if (portalIsOpen)
        {Destroy(this.gameObject);}
    }
}
