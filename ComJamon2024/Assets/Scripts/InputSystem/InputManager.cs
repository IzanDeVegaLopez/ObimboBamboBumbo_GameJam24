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

    bool heal = false;

    private PlayerControls _controls;
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

    }
    public void Prueba(InputAction.CallbackContext context)
    {
        if (context.interaction is PressInteraction) Debug.Log("press");
        else Debug.Log("hold");
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
