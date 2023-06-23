using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            }
        else
        {
            Destroy(gameObject);
        }
    }


    public void MainMenu()
    {
        print("MainMenu");
        SceneManager.LoadScene("StartScreen");
    }

    public void StartGame()
    {
        print("startGame");
        SceneManager.LoadScene("GamePlay");
    }   
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        print("gameover");
        SceneManager.LoadSceneAsync("EndScreen");
    }
}
