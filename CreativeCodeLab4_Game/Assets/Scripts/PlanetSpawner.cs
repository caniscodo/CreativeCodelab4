using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberOfObjects;
    public int objectLimit;
    public Vector3 spawnArea;

    private int spawnedObjects = 0;

    private void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            if (spawnedObjects >= objectLimit)
                break;

            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(-spawnArea.y, spawnArea.y),
                Random.Range(-spawnArea.z, spawnArea.z)
            );

            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            spawnedObjects++;
        }
    }
}