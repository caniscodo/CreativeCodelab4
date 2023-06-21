using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GlobalData.instance.decreaseHealth(2);
           print("AsteroidDecreasedPlayerHEalth");
        }
    }
}
