using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {
       
        if(gameObject.CompareTag("Player")) 
        print("spider triggered");
        animator.SetTrigger("SpiderTriggered");
        
        PlayerMovement.instance.spiderEffect();
    }
}
