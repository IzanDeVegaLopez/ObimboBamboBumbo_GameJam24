using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPerformer : MonoBehaviour
{
    ComboSystem _comboSystem;

    bool _isAttacking = false;
    bool _isCancellable = false;
    bool _lastAttackHit = false;

    AnimatorController _anim;

    private void Start()
    {
        _comboSystem = GetComponent<ComboSystem>();
        _anim = GetComponent<AnimatorController>();
    }

    public void TryAttacking()
    {
        //Esto debería llamar a que empiece la animación.
        if (!_isAttacking || _isCancellable)
        {
            _isCancellable = false;
            _isAttacking = true;
            _anim.StartAttackAnim((int)_comboSystem.currentComboState);

        }

    }

    public void PerformAttack()
    {
        _lastAttackHit = _comboSystem.Attack();
        _isCancellable = true;
        Debug.Log(_lastAttackHit);
    }

    public void EndAttack()
    {
        _isAttacking = false;
        _isCancellable = false;
        _anim.AttackFinished();
        _comboSystem.resetComboState();
    }
}
