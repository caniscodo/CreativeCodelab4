using UnityEngine;

public class DontDestroyOnLoadManager : MonoBehaviour
{
    private static DontDestroyOnLoadManager instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this instance as the singleton instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another instance already exists, destroy this one
            Destroy(gameObject);
        }
    }
}