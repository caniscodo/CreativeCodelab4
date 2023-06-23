using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePartLoader : MonoBehaviour
{
    public Transform player;
    public float loadRange;

    private bool isLoaded;
    private Scene loadedScene;

    private void Start()
    {
        // Verify if the scene is already open to avoid opening a scene twice
        Scene targetScene = SceneManager.GetSceneByName(gameObject.name);
        isLoaded = targetScene.isLoaded;
        loadedScene = targetScene;
    }

    private void LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
        asyncLoad.completed += (operation) =>
        {
            loadedScene = SceneManager.GetSceneByName(gameObject.name);
            SceneManager.SetActiveScene(loadedScene);
        };
        isLoaded = true;
    }

    private void UnloadScene()
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(gameObject.name);
        asyncUnload.completed += (operation) => isLoaded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isLoaded)
            {
                LoadScene();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isLoaded)
            {
                UnloadScene();
            }
        }
    }
}