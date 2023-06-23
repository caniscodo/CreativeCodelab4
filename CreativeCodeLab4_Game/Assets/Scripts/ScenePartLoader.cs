/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePartLoader : MonoBehaviour
{
    // Load Scenes in predefined Level Area of Triggers
    public Transform player;
    public float loadRange;

    private int buildIndex;
    private bool[] isLoaded;

    private void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        isLoaded = new bool[SceneManager.sceneCountInBuildSettings];

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            Scene targetScene = SceneManager.GetSceneByBuildIndex(i);
            isLoaded[i] = targetScene.isLoaded;
        }

        for (int i = buildIndex + 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            if (!isLoaded[i])
            {
                LoadScene(i);
            }
            else
            {
                isLoaded[i] = true; // Set the flag to true for scenes that are already loaded
            }
        }
    }

    private void LoadScene(int buildIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        asyncLoad.completed += (operation) =>
        {
            isLoaded[buildIndex] = true;
        };
    }

    private void UnloadScene(int buildIndex)
    {
        if (isLoaded[buildIndex])
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(buildIndex);
            asyncUnload.completed += (operation) => isLoaded[buildIndex] = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = buildIndex + 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                if (!isLoaded[i])
                {
                    LoadScene(i);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = buildIndex + 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                if (isLoaded[i])
                {
                    UnloadScene(i);
                }
            }
        }
    }
}
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePartLoader : MonoBehaviour
{
    //Load Scenes in predefined Level Area of Triggers
    public Transform player;
    public float loadRange;

    private bool isLoaded;
    private Scene loadedScene;

    private void Start()
    {
       
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
