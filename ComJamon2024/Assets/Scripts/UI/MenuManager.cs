using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Lista de menús:
    /// 0 - Pausa
    /// 1 - Acto
    /// </summary>
    [SerializeField]
    private GameObject[] _menuList;

    // Botón seleccionado por defecto en cada menú. Referenciar en el mismo orden de menús
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
        _menuList[menuId].SetActive(true);
        _firstSelected[menuId].Select();

        _inputM.controls.Player.Disable();
        _inputM.controls.UI.Enable();
    }
    #endregion

    private void Start()
    {
        _inputM.controls.UI.CloseMenu.performed += CloseMenu;
    }
}
