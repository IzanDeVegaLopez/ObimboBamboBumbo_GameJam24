using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{
    #region references
    private CharacterMovement _charMov;
    private AttackPerformer _attPerf;
    private AbilityHandler _abiHan;

    [SerializeField]
    private MenuManager _menuManager;


    private PlayerControls _controls;

    public PlayerControls controls { 
        get { return _controls; } 
        set { _controls = value; } 
    }
    #endregion

    private void OnEnable()
    {
        _controls.Enable();

        _controls.Player.Move.performed += Move;
        _controls.Player.Move.canceled += Move;
        _controls.Player.Jump.performed += JumpPressed;
        _controls.Player.Jump.canceled += JumpReleased;
        _controls.Player.Dash.performed += Dash;
        _controls.Player.BasicAttack.performed += BasicAttack;
        _controls.Player.Abilities.performed += Abilities;
        _controls.Player.Pause.performed += PauseGame;
    }

    private void OnDisable()
    {
        _controls.Disable();

        _controls.Player.Move.performed -= Move;
        _controls.Player.Move.canceled -= Move;
        _controls.Player.Jump.performed -= JumpPressed;
        _controls.Player.Jump.canceled -= JumpReleased;
        _controls.Player.Dash.performed -= Dash;
        _controls.Player.BasicAttack.performed -= BasicAttack;
        _controls.Player.Abilities.performed -= Abilities;
        _controls.Player.Pause.performed -= PauseGame;

    }


    #region movement
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        _charMov.SetXInput(input.x);
        _charMov.SetYInput(input.y);
    }

    public void JumpPressed(InputAction.CallbackContext context)
    {
        _charMov.JumpPressed();
    }

    public void JumpReleased(InputAction.CallbackContext context)
    {
        _charMov.JumpReleased();
    }

    public void Dash(InputAction.CallbackContext context)
    {
        _charMov.DashPressed();
    }

    #endregion

    #region attack & abilities
    public void BasicAttack(InputAction.CallbackContext context)
    {
        _attPerf.TryAttacking();
    }

    public void Abilities(InputAction.CallbackContext context)
    {
        if (context.interaction is PressInteraction) SpecialAttack();
        else if (context.interaction is HoldInteraction) Heal();
    }
    private void SpecialAttack()
    {
        _abiHan.ExecuteAbility();
    }

    private void Heal()
    {
        _abiHan.HealAbility();
    }
    #endregion

    #region menus
    public void PauseGame(InputAction.CallbackContext context)
    {
        GameManager.Instance.PauseGame();
    }
    #endregion

    private void Awake()
    {
        _controls = new PlayerControls();
    }

    void Start()
    {
        _charMov = GetComponent<CharacterMovement>();  
        _attPerf = GetComponent<AttackPerformer>();
        _abiHan = GetComponent<AbilityHandler>();
    }
}
