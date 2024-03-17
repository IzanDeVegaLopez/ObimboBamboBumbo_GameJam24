using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MenuManager : MonoBehaviour
{

    private static MenuManager _instance;
    public static MenuManager Instance
    {
        get { return _instance; }
    }

    /// <summary>
    /// Lista de men�s:
    /// 0 - Pausa
    /// 1 - Acto 1
    /// 2 - Acto 2
    /// 3 - Acto 3
    /// </summary>
    [SerializeField]
    private GameObject[] _menuList;

    // Bot�n seleccionado por defecto en cada men�. Referenciar en el mismo orden de men�s
    [SerializeField]
    private Button[] _firstSelected;

    [SerializeField]
    private InputManager _inputM;


    //private void OnEnable()
    //{
    //    _inputM.controls.UI.CloseMenu.performed += CloseMenu;
    //}

    //private void OnDisable()
    //{
    //    _inputM.controls.UI.CloseMenu.performed -= CloseMenu;
    //}


    #region methods
    public void CloseMenu(InputAction.CallbackContext context)
    {
        Debug.Log("cerrar menu");
        CloseMenu();
    }
    public void CloseMenu()
    {
        foreach (GameObject menu in _menuList) menu.SetActive(false);

        _inputM.controls.UI.Disable();
        _inputM.controls.Player.Enable();
    }

    public void OpenMenu(int menuId)
    {
        _menuList[Mathf.Abs(menuId)].SetActive(true);
        _firstSelected[Mathf.Abs(menuId)].Select();

        _inputM.controls.Player.Disable();
        _inputM.controls.UI.Enable();
    }
    #endregion

    void Awake()
    {
        if (_instance != null) Destroy(gameObject);
        else _instance = this;
    }

    private void Start()
    {
        _inputM.controls.UI.CloseMenu.performed += CloseMenu;
    }
}
