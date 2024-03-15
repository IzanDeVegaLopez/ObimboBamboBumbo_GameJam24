using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName ="AbilityData/HealData")]
public class HealAbility : AbilityData
{
    HealthHandler _myHealthHandler;
    public override void ExecuteAbility(AbilityHolder abilityHolder)
    {
        _myHealthHandler = abilityHolder.GetComponent<HealthHandler>();
        //Ejecutar animación
        _myHealthHandler.Heal(); //Se puede poner como evento de animación y es mejor, es solo para probar
    }
}
