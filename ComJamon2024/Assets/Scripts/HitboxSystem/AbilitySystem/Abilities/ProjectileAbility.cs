using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "AbilityData/ProjectileData")]
public class ProjectileAbility : AbilityData
{
    [SerializeField] GameObject _projectilePrefab;

    CharacterMovement _chMov;

    GameObject _projectile;

    public override void ExecuteAbility(AbilityHolder abilityHolder)
    {
        _chMov = abilityHolder.GetComponent<CharacterMovement>();
        _chMov.SetAnchored(true);

        Instantiate(_projectilePrefab,_chMov.transform.position + 0.5f*Vector3.up, Quaternion.identity).GetComponent<NeedleProjectileComponent>().GetReferenceToProjectileAbility(this);
    }

    public void Finished()
    {
        _chMov.SetAnchored(false);
    }

}
