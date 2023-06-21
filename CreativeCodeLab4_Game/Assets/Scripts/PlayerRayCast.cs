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
                    Destroy(hit.collider.gameObject);
                    /*if (raycastTimer <= 0f)
                        raycastTimer = Time.time;

                    if (Time.time - raycastTimer >= raycastDuration)
                    {
                        
                    }*/
                }
                else
                {
                    raycastTimer = 0f;
                }

                // Visualize the raycast using a particle system
                /*if (raycastParticle != null)
                {
                    raycastParticle.transform.position = hit.point;
                    raycastParticle.Play();
                }*/
            }
            else
            {
                raycastTimer = 0f;
            }

            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        }
    }
}