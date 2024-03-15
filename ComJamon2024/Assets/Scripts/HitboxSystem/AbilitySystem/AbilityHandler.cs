using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] static AbilityHolder[] _abilities = new AbilityHolder[4];

    private int _abilityIndex = 1; //El 0 está reservado para la HealAbility
    public int abilityIndex { set => _abilityIndex = value; }

    void ExecuteAbility()
    {
        _abilities[_abilityIndex].UseAbility();
    }

    void HealAbility()
    {
        _abilities[0].UseAbility();
    }
}
