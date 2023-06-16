using UnityEngine;
using System.Collections.Generic;

public class OldOrbSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberOfObjects;
    public string[] inclusionTags;
    public Material[] availableMaterials;

    private int spawnedObjects = 0;
    private List<Vector3> existingOrbPositions = new List<Vector3>();

    private void Start()
    {
        GameObject[] platformObjects = GameObject.FindGameObjectsWithTag("Platform");

        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject randomPlatformObject = GetRandomPlatformObject(platformObjects);
            if (randomPlatformObject == null)
                continue;

            GameObject orbSpawnArea = GetOrbSpawnArea(randomPlatformObject);
            if (orbSpawnArea == null)
                continue;

            if (randomPlatformObject.GetComponentInChildren<Collectible>() != null)
            {
                i--;
                continue;
            }
               
            
            Vector3 spawnPosition = GenerateRandomSpawnPosition(randomPlatformObject, orbSpawnArea);

            Material randomMaterial = GetRandomMaterial();
            GameObject spawnedObject = Instantiate(objectPrefab, randomPlatformObject.transform);
            ApplyMaterialToGameObject(spawnedObject, randomMaterial);

            spawnedObjects++;

            if (spawnedObjects >= numberOfObjects)
                break;
        }
    }

    private GameObject GetRandomPlatformObject(GameObject[] platformObjects)
    {
        if (platformObjects.Length == 0)
            return null;

        int randomIndex = Random.Range(0, platformObjects.Length);
        return platformObjects[randomIndex];
    }

    private GameObject GetOrbSpawnArea(GameObject platformObject)
    {
        Transform orbSpawnArea = platformObject.transform.Find("OrbSpawnArea");
        if (orbSpawnArea != null)
            return orbSpawnArea.gameObject;

        return null;
    }

    private Vector3 GenerateRandomSpawnPosition(GameObject platformObject, GameObject orbSpawnArea)
{
    Vector3 spawnPosition = orbSpawnArea.transform.position;
    Renderer platformRenderer = orbSpawnArea.GetComponent<Renderer>();
    MeshCollider meshCollider = orbSpawnArea.GetComponent<MeshCollider>();

    if (platformRenderer != null && meshCollider != null && meshCollider.sharedMesh != null)
    {
        Vector3[] vertices = meshCollider.sharedMesh.vertices;
        int[] triangles = meshCollider.sharedMesh.triangles;

        List<Vector3> surfaceVertices = new List<Vector3>();

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 v1 = orbSpawnArea.transform.TransformPoint(vertices[triangles[i]]);
            Vector3 v2 = orbSpawnArea.transform.TransformPoint(vertices[triangles[i + 1]]);
            Vector3 v3 = orbSpawnArea.transform.TransformPoint(vertices[triangles[i + 2]]);

            Vector3 normal = Vector3.Cross(v2 - v1, v3 - v1).normalized;

            if (normal.y > 0f)
            {
                surfaceVertices.Add(v1);
                surfaceVertices.Add(v2);
                surfaceVertices.Add(v3);
            }
        }

        Vector3 randomPointOnSurface = Vector3.zero;
        bool foundValidPoint = false;
        int maxAttempts = 100;

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomVertex = surfaceVertices[Random.Range(0, surfaceVertices.Count)];
            Vector3 randomPoint = randomVertex + Vector3.up * Random.Range(0f, 2f);

            randomPointOnSurface = randomPoint;

            // Check if the random point is too close to an existing orb
            bool tooCloseToExistingOrb = false;
            foreach (Vector3 existingPosition in existingOrbPositions)
            {
                if (Vector3.Distance(randomPoint, existingPosition) < 0.1f)
                {
                    tooCloseToExistingOrb = true;
                    break;
                }
            }

            // Check if the random point is too close to other spawned objects
            Collider[] colliders = Physics.OverlapSphere(randomPoint, 0.1f);
            bool tooCloseToOtherObjects = colliders.Length > 0;

            if (!tooCloseToExistingOrb && !tooCloseToOtherObjects)
            {
                foundValidPoint = true;
                break;
            }
        }

        if (foundValidPoint)
        {
            spawnPosition = randomPointOnSurface;
            existingOrbPositions.Add(spawnPosition);
        }
    }

    float objectHeight = objectPrefab.transform.localScale.y * objectPrefab.GetComponent<Renderer>().bounds.size.y;
    spawnPosition.y = orbSpawnArea.transform.position.y + objectHeight / 2f;

    return spawnPosition;
}


    private Material GetRandomMaterial()
    {
        int randomIndex = Random.Range(0, availableMaterials.Length);
        return availableMaterials[randomIndex];
    }

    private void ApplyMaterialToGameObject(GameObject gameObject, Material material)
    {
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material = material;
        }
    }
}
