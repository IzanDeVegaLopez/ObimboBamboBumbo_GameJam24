using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPerformer : MonoBehaviour
{
    [SerializeField]
    ComboSystem _comboSystem;

    bool _isAttacking = false;
    bool _lastAttackHit = false;

    private void Start()
    {
        _comboSystem = GetComponent<ComboSystem>();
    }

    public void TryAttacking()
    {
        if (!_isAttacking)
        {
            _isAttacking = true;
            _lastAttackHit = _comboSystem.Attack();
        }

    }

    public void EndAttack()
    {
        _isAttacking = false;
    }
}
