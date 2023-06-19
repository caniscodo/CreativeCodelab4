using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalWallMechanics : MonoBehaviour
{
    public static PortalWallMechanics instance;

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

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        if(PortalOpener.instance.portalIsOpen == true)
        {Destroy(this.gameObject);}
    }
}
