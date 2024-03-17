using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] ManaManager _mana;

    [SerializeField] AbilityHolder[] _abilities = new AbilityHolder[4];

    [SerializeField] AbilitySelector _selector;

    AnimatorController _anim;

    CharacterMovement _chMov;
    HealthHandler _healthHandler;

    //AttackPerformer _aPerformer;

    [SerializeField]
    [Range(1,3)]
    private int _abilityIndex; //El 0 está reservado para la HealAbility
    public int abilityIndex { set => _abilityIndex = value; }

    void Start()
    {
        //_aPerformer = GetComponent<AttackPerformer>();
        _anim = GetComponent<AnimatorController>();
        _chMov = GetComponent<CharacterMovement>();
        _healthHandler = GetComponent<HealthHandler>();
        _abilityIndex = _selector.abilityIndex;
    }

    public void ExecuteAbility()
    {
        if (_mana.currentMana < _abilities[_abilityIndex].aData.manaCost || CharacterMovement.Anchored) return;
        //_mana.currentMana -= _abilities[_abilityIndex].aData.manaCost;
        _abilities[_abilityIndex].UseAbility();
        _anim.StartAttackAnim(-_abilityIndex);
        _mana.currentMana -= _abilities[_abilityIndex].aData.manaCost;


    }

    public void HealAbility()
    {
        _abilities[0].UseAbility();
    }

    public void returnToNormalParryCounter()
    {
        _anim.ParryCounter(false);
    }

    public void FinishBlockingStance()
    {
        _chMov.SetAnchored(false);
        _healthHandler.SetBlock(false);
    }
}
