using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "AbilityData/DashData")]
public class DashAbility : AbilityData
{
    [SerializeField] GameObject _hitbox;
    [SerializeField] int _dashForce;
    private Vector3 _instantiationPoint;
    //private CharacterMovement _characterMovement;
    private Rigidbody2D _rb;

    public override void ExecuteAbility(AbilityHolder abilityHolder)
    {
        //_characterMovement = abilityHolder.GetComponent<CharacterMovement>();
        _rb = abilityHolder.GetComponent<Rigidbody2D>();
        _rb.velocity = Vector3.zero;

        if (CharacterMovement.Direction >= 0)
        {
            Instantiate(_hitbox, abilityHolder.transform.position + _instantiationPoint, Quaternion.identity);
            _rb.AddForce(Vector3.right * _dashForce, ForceMode2D.Impulse);
        }
        else
        {
            Instantiate(_hitbox, abilityHolder.transform.position - _instantiationPoint, Quaternion.identity);
            _rb.AddForce(Vector3.left * _dashForce, ForceMode2D.Impulse);
        }
    }
}
