using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOpener : MonoBehaviour
{
    private static PortalOpener instance;
    public bool IsStandingInPortal { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        IsStandingInPortal = false;
    }

    private void OnTriggerStay(Collider other)
    {
        IsStandingInPortal = true;
    }
}
