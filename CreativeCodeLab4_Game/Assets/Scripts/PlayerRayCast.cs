using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRayCast : MonoBehaviour
{
    public Transform raycastStartPoint;
    public ParticleSystem raycastParticle; // Reference to the particle system

    private float raycastDuration = 1f;
    private float raycastTimer;
    private bool isRaycastActive;

    private void Update()
    {
        isRaycastActive = true;

        if (isRaycastActive)
        {
            Ray ray = new Ray(raycastStartPoint.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Destroyable"))
                {
                    print("player destroyed asteroid");
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    raycastTimer = 0f;
                }
                
            }
            else
            {
                raycastTimer = 0f;
            }

            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        }
    }
}