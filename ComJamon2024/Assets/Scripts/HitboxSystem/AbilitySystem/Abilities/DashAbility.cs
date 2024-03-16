using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "AbilityData/DashData")]
public class DashAbility : AbilityData
{
    [SerializeField] float _dashForce;
    [SerializeField] float _duration;

    public override void ExecuteAbility(AbilityHolder abilityHolder)
    {
        if (manaManager.currentMana >= manaCost)
        {
            abilityHolder.GetComponent<CharacterMovement>().DashAttack(_dashForce, _duration);
            //abilityHolder.GetComponent<AnimatorController>().StartAttackAnim(-1);
            manaManager.currentMana -= manaCost;
        }
    }

}
