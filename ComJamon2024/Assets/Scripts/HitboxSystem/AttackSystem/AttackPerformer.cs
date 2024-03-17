using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPerformer : MonoBehaviour
{
    ComboSystem _comboSystem;
    [SerializeField]
    bool _isAttacking = false;
    [SerializeField]
    bool _isCancellable = false;

    float _attackInputBuffer = 0.2f;
    float _lastTimeAttackPressed = -10;

    AnimatorController _anim;
    CharacterMovement _chMov;

    private void Start()
    {
        _comboSystem = GetComponent<ComboSystem>();
        _anim = GetComponent<AnimatorController>();
        _chMov = GetComponent<CharacterMovement>();
    }

    public void TryAttacking()
    {
        _lastTimeAttackPressed = Time.time;
    }

    private void Update()
    {
        if ((!_isAttacking || _isCancellable) && !CharacterMovement.Anchored && (Time.time - _lastTimeAttackPressed < _attackInputBuffer))
        {
            //_isAttacking = true;
            _anim.StartAttackAnim((int)_comboSystem.currentComboState);
            _lastTimeAttackPressed = 0;
            _anim.PlayCutEffect();
            _chMov.BlockMovement(true);

        }
    }

    //Se llama en el primer frame de animacion
    public void InitAttack()
    {
        _isCancellable = false;
        _isAttacking = true;
    }

    public void PerformAttackComboCancellable()
    {
        _comboSystem.Attack();
        _isCancellable = true;
        _chMov.BlockMovement(false);
    }

    public void PerformAttack()
    {
        _comboSystem.Attack();
        _chMov.BlockMovement(false);
    }

    public void EndAttack()
    {
        _isAttacking = false;
        _isCancellable = false;
        _anim.AttackFinished();
        _comboSystem.resetComboState();
        _chMov.SetAnchored(false);
    }
}
