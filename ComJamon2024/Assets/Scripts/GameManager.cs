using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }


    #region references
    private MenuManager _menuManager;

    #endregion
    public void FindMenuManager() => _menuManager = FindAnyObjectByType<MenuManager>();

    public void PauseGame()
    {
        FindMenuManager();
        Time.timeScale = 0;
        _menuManager.OpenMenu(0);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        _menuManager.CloseMenu();
    }

    public void PlayerInput()
    {
        _menuManager.inputM.SwitchToPlayer();
    }    

    public void UIInput()
    {
        _menuManager.inputM.SwitchToUI();
    }

    void Awake()
    {
        if (_instance != null) Destroy(this);
        else _instance = this;
    }

    private void Start()
    {
        FindMenuManager();
    }
}
