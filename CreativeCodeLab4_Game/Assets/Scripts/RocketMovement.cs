using System;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float duration = 20f;

    private float t = 0f;

    private void Update()
    {
        t += Time.deltaTime / duration;

        if (t > 1f)
        {
            t = 1f;
        }

        Vector3 position = Vector3.Lerp(startPoint.position, endPoint.position, t);
        transform.position = position;
        
        DestroyAfterArrival();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("rocket hit player");
            GlobalData.instance.decreaseHealth(1);
            Destroy(this.gameObject);
        }
    }

    private void DestroyAfterArrival()
    {
        if (transform.position == endPoint.position)
        {
            print("rocket end");
        }
        
    }
}