using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "AbilityData/ProjectileData")]
public class ProjectileAbility : AbilityData
{
    [SerializeField] GameObject _hitbox;
    [SerializeField] float _dashForce;
    [SerializeField] float _duration;



    //private Vector3 _instantiationPoint;
    //private CharacterMovement _characterMovement;
    //private Rigidbody2D _rb;

    public override void ExecuteAbility(AbilityHolder abilityHolder)
    {
        
    }

}
