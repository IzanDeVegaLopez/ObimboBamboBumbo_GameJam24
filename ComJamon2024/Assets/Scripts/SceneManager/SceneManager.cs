using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] SceneManagement sceneManagement;
    
    public void Restart()
    {
        sceneManagement.actualScene = 9;
        SceneManager.LoadScene(sceneBuildIndex: sceneManagement.actualScene);
    }

    public void LoadNextScene()
    {
        sceneManagement.actualScene++;
        SceneManager.LoadScene(sceneBuildIndex: sceneManagement.actualScene);
    }

    public void ReturnToMainMenu()
    {
        sceneManagement.actualScene = 0;
        SceneManager.LoadScene(sceneBuildIndex: sceneManagement.actualScene);
    }

    public void LoadCredits()
    {
        sceneManagement.actualScene = 8;
        SceneManager.LoadScene(sceneBuildIndex: sceneManagement.actualScene);
    }

    public void LoadActI()
    {
        sceneManagement.actualScene = 2;
        SceneManager.LoadScene(sceneBuildIndex: sceneManagement.actualScene);
    }
}
