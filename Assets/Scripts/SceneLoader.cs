using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Class for managing the loading of scenes
 */

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    // Singleton
    private void Awake()
    {
        Instance = this;
    }

    // Loads the start scene
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title Screen");
    }

    // Loads the tutorial scene
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial Screen");
    }

    // Loads the gameplay scene
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Test Scene");
    }

    // Loads the game over scene
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("End Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
