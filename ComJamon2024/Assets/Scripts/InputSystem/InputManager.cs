using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region references
    private CharacterMovement _charMov;
    private AttackPerformer _attPerf;
    private AbilityHandler _abiHan;

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
        _controls.Player.SpecialAbility.canceled += SpecialAbility;
        _controls.Player.Heal.performed += Heal;
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
        _controls.Player.SpecialAbility.canceled -= SpecialAbility;
        _controls.Player.Heal.performed -= Heal;

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

    public void SpecialAbility(InputAction.CallbackContext context)
    {
        _abiHan.ExecuteAbility();
    }

    public void Heal(InputAction.CallbackContext context)
    {
        Debug.Log("hola me estoy curando");
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
