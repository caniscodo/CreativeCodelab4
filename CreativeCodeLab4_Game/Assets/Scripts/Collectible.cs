using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        print("collision with collectible");
        if (collider.CompareTag("Player"))
        {
            GlobalData.instance.increaseHealth(1);
            Destroy(this.gameObject);
        }
    }
}

