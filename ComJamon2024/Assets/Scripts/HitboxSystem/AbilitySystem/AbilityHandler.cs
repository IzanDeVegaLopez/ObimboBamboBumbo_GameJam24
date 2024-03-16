using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] ManaManager _mana;

    [SerializeField] AbilityHolder[] _abilities = new AbilityHolder[4];

    AttackPerformer _aPerformer;

    [SerializeField]
    [Range(1,3)]
    private int _abilityIndex = 1; //El 0 está reservado para la HealAbility
    public int abilityIndex { set => _abilityIndex = value; }

    void Start()
    {
        _aPerformer = GetComponent<AttackPerformer>();
    }

    public void ExecuteAbility()
    {
        if (_mana.currentMana < _abilities[_abilityIndex].aData.manaCost || CharacterMovement.Anchored) return;
        //_mana.currentMana -= _abilities[_abilityIndex].aData.manaCost;
        _abilities[_abilityIndex].UseAbility();
    }

    public void HealAbility()
    {
        _abilities[0].UseAbility();
    }
}
