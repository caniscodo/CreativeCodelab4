using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerMovement.gameObject)
        {
            return;
        }
        
        PlayerMovement.setGrounded(true);
    }    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerMovement.gameObject)
        {
            return;
        }
        
        PlayerMovement.setGrounded(false);
    }   
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == PlayerMovement.gameObject)
        {
            return;
        }
        
        PlayerMovement.setGrounded(true);
    }
    */
    
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject == PlayerMovement.gameObject)
        {
            return;
        }
        
        PlayerMovement.setGrounded(true);
    }    
    
    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject == PlayerMovement.gameObject)
        {
            return;
        }
        
        PlayerMovement.setGrounded(false);
    }   
    
    private void OnCollisionStay(Collision collider)
    {
        if (collider.gameObject == PlayerMovement.gameObject)
        {
            return;
        }
        
        PlayerMovement.setGrounded(true);
    }
}
