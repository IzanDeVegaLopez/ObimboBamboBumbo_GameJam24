using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parry", menuName = "AbilityData/ParryData")]
public class ParryAbility : AbilityData
{
    //La animaci�n finaliza el ataque
    public override void ExecuteAbility(AbilityHolder abilityHolder)
    {
        HealthHandler _myHealthHandler = abilityHolder.GetComponent<HealthHandler>();

        _myHealthHandler.SetBlock(true);
    }
}