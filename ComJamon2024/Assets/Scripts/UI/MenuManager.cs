using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MenuManager : MonoBehaviour
{

    private static MenuManager _instance;
    public static MenuManager Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    private GameObject[] _menuList;

    [SerializeField]
    private Button[] _firstSelected;

    #region methods
    public void CloseMenu()
    {
        foreach (GameObject menu in _menuList) menu.SetActive(false);
    }

    public void OpenMenu(int menuId)
    {
        _menuList[menuId].SetActive(true);
    }
    #endregion

    void Awake()
    {
        if (_instance != null) Destroy(gameObject);
        else _instance = this;
    }

    void Start()
    {
        
    }

}
