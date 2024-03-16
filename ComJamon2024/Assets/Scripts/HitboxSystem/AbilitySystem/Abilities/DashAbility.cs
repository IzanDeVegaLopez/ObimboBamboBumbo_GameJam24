using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "AbilityData/DashData")]
public class DashAbility : AbilityData
{
    [SerializeField] GameObject _hitbox;
    [SerializeField] float _dashForce;
    [SerializeField] float _duration;



    //private Vector3 _instantiationPoint;
    //private CharacterMovement _characterMovement;
    //private Rigidbody2D _rb;

    public override void ExecuteAbility(AbilityHolder abilityHolder)
    {
        abilityHolder.GetComponent<CharacterMovement>().DashAttack(_dashForce, _duration);
        abilityHolder.GetComponent<AnimatorController>().StartAttackAnim(-1);
    }

}
