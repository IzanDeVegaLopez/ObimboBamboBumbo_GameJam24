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
        if (_myHealthHandler.maxHealth > _myHealthHandler.currentHealth && manaManager.currentMana >= manaCost)
        {
            _myHealthHandler.Heal(); //Ejecutar animación. Se puede poner como evento de animación y es mejor, es solo para probar
            manaManager.currentMana -= manaCost;
        }
        //else Ejecutar animación de que no se ha curado
    }
}
