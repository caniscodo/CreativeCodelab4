using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeWithoutPortal : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("Level1");
    }
}
