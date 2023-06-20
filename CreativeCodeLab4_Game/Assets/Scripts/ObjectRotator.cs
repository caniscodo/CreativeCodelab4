using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float minSpeed = 0.1f;
    public float maxSpeed = 1.0f;

    private float speed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}