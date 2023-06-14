using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public Transform startPoint;  // Game object defining the start point
    public Transform endPoint;    // Game object defining the end point

    public float duration = 2f;   // Duration of the movement
    public float frequency = 1f;  // Frequency of the sine curve

    private float t = 0f;         // Current time

    private void Update()
    {
        t += Time.deltaTime / duration;  // Increment time based on duration

        if (t > 1f)
        {
            t = 1f;  // Clamp time to 1 when it reaches or exceeds 1
        }

        // Calculate the position along the sine curve using the start and end points
        Vector3 position = CalculateSinePoint(startPoint.position, endPoint.position, t, frequency);

        transform.position = position;  // Set the position of the game object
    }

    // Calculate a point on the sine curve given the start, end, t, and frequency values
    private Vector3 CalculateSinePoint(Vector3 start, Vector3 end, float t, float frequency)
    {
        // Calculate the position on the curve using the formula
        float x = Mathf.Lerp(start.x, end.x, t);  // Linear interpolation for x position
        float y = Mathf.Lerp(start.y, end.y, t);  // Linear interpolation for y position
        float z = Mathf.Lerp(start.z, end.z, t);  // Linear interpolation for z position

        float amplitude = (endPoint.position.y - startPoint.position.y) / 2f;
        float yOffset = Mathf.Sin(t * frequency * 2f * Mathf.PI) * amplitude;

        return new Vector3(x, y + yOffset, z);
    }
}