using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] SceneManagement sceneManagement;
    private void Awake()
    {
        sceneManagement.actualScene = 0;
    }
}
