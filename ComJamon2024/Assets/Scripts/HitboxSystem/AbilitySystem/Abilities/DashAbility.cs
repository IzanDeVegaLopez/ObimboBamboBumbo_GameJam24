using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : AbilityData
{
    CharacterMovement _myCharacterMovement;
    BoxCollider2D _boxCollider;

    public override void ExecuteAbility(AbilityHolder abilityHolder)
    {
        _myCharacterMovement = abilityHolder.GetComponent<CharacterMovement>();
        _boxCollider = abilityHolder.GetComponent<BoxCollider2D>();
        _boxCollider.isTrigger = true;
        _myCharacterMovement.DashPressed();
    }
}
