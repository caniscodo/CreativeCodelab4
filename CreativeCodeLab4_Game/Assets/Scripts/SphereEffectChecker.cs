using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SphereEffectChecker : MonoBehaviour
{
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Volume>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.GetComponent<Volume>().enabled = false;
    }
}
