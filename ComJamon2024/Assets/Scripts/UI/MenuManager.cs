using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    public InputManager inputM
    {
        get { return _inputM; }
    }

    public bool isGameplay;

    #region methods
    public void CloseMenu(InputAction.CallbackContext context)
    {
        CloseMenu();
    }
    public void CloseMenu()
    {
        foreach (GameObject menu in _menuList) menu.SetActive(false);

        _inputM.controls.Player.Enable();
        _inputM.controls.UI.Disable();
    }

    public void OpenMenu(int menuId)
    {
        _menuList[menuId].SetActive(true);
        _firstSelected[menuId].Select();

        _inputM.controls.UI.Enable();
        _inputM.controls.Player.Disable();
    }

    public void SelectButton() => _firstSelected[0].Select();
    #endregion

    private void Start()
    {
        if (!isGameplay) SelectButton();
    }
}
