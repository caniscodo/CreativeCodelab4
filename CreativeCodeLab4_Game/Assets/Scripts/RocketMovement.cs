using System;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public Transform startPoint;  
    public Transform endPoint;    

    public float duration = 20f;   
    public float frequency = 2f;  

    private float t = 0f;         

    private void Update()
    {
        t += Time.deltaTime / duration; 

        if (t > 1f)
        {
            t = 1f;  
        }

      
        Vector3 position = CalculateSinePoint(startPoint.position, endPoint.position, t, frequency);

        transform.position = position;  
    }
    
    private Vector3 CalculateSinePoint(Vector3 start, Vector3 end, float t, float frequency)
    {
        float x = Mathf.Lerp(start.x, end.x, t);  
        float y = Mathf.Lerp(start.y, end.y, t);  
        float z = Mathf.Lerp(start.z, end.z, t);  
        float amplitude = (endPoint.position.y - startPoint.position.y) / 2f;
        float yOffset = Mathf.Sin(t * frequency * 0.2f * Mathf.PI) * amplitude;

        return new Vector3(x, y + yOffset, z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GlobalData.instance.decreaseHealth(1);
        }
    }
}