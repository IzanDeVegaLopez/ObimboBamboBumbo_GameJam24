using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] SceneManagement sceneManagement;

    public bool isGameplay;
    [SerializeField]
    private MenuManager _menuManager;

    public void Restart()
    {
        sceneManagement.actualScene = 9;
        SceneManager.LoadScene(sceneBuildIndex: sceneManagement.actualScene);
        GameManager.Instance.FindMenuManager();
    }

    public void LoadNextScene()
    {
        sceneManagement.actualScene++;
        SceneManager.LoadScene(sceneBuildIndex: sceneManagement.actualScene);
        GameManager.Instance.FindMenuManager();
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
        GameManager.Instance.FindMenuManager();
    }

    private void Start()
    {
        if (!isGameplay) _menuManager.SelectButton();
    }
}
