using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDeath : MonoBehaviour
{
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
        print("floor killed kitty");
        GlobalData.instance.decreaseHealth(5);

    }
}