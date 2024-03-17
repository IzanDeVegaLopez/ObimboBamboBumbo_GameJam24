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
        SceneManager.LoadScene("ActI");
    }

    public void LoadNextScene()
    {
        sceneManagement.actualScene++;
        SceneManager.LoadScene(sceneBuildIndex: sceneManagement.actualScene);
    }
}
