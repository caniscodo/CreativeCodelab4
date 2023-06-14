using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberOfObjects;
    /*public int objectLimit;*/
    public Vector3 spawnArea;
    public string[] exclusionTags;
    public Material[] availableMaterials;

    private int spawnedObjects = 0;

    private void Awake()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = GenerateRandomSpawnPosition();

            
            if (IsPositionInExclusionZone(spawnPosition))
                continue;

            Material randomMaterial = GetRandomMaterial();
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            ApplyMaterialToGameObject(spawnedObject, randomMaterial);

            spawnedObjects++;

            if (spawnedObjects >= numberOfObjects)
                break;
        }
    }


    private Vector3 GenerateRandomSpawnPosition()
    {
        return transform.position + new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            Random.Range(-spawnArea.z, spawnArea.z)
        );
    }

    private bool IsPositionInExclusionZone(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f);
        foreach (Collider collider in colliders)
        {
            foreach (string tag in exclusionTags)
            {
                if (collider.CompareTag(tag))
                    return true;
            }
        }
        return false;
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
