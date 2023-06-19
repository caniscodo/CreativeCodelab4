using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalWallMechanics : MonoBehaviour
{
    public static PortalWallMechanics instance;
    private bool portalIsOpen = PortalOpener.instance.portalIsOpen;

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

    private void Update()
    {
        print($" Portal is open in Wall is {portalIsOpen}");
        if (PortalOpener.instance.portalIsOpen == true)
        {Destroy(this.gameObject);}
    }
}
