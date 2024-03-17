using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parry", menuName = "AbilityData/ParryData")]
public class ParryAbility : AbilityData
{
    CharacterMovement _chMov;
    HealthHandler _myHealthHandler;

    //La animación finaliza el ataque y llama al counter attack de abilityAttacks
    public override void ExecuteAbility(AbilityHolder abilityHolder)
    {
        _chMov = abilityHolder.GetComponent<CharacterMovement>();
        _chMov.SetAnchored(true);
        _myHealthHandler = abilityHolder.GetComponent<HealthHandler>();
        _myHealthHandler.SetBlock(true);
        
    }
}