using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public bool IsNextSceneWinScreen()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        string nextSceneName = NameOfSceneByBuildIndex(currentSceneIndex + 1);
        return nextSceneName == "Win Screen";
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private string NameOfSceneByBuildIndex(int buildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(buildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
}
