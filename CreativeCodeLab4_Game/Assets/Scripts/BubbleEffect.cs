/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleEffect : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject bubbleEffectObject = GameObject.Find("Canvas");
        if (bubbleEffectObject != null)
        { print("Bubble Object Found");
            /*bubbleEffectObject.GetComponent<Image>().enabled = false;#1#
        }
        else
        {
            Debug.Log("BubbleEffect GameObject not found.");
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("BubbleCanvas").SetActive(true);
            print("bubbleOn");
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
     if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("BubbleCanvas").SetActive(false);
            print("bubbleOff");
        }
        
    }
}
*/
