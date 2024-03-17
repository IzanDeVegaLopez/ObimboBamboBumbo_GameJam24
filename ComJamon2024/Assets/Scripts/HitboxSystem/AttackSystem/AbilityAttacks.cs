using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityAttack : HitboxHandler
{
    [SerializeField]
    HitboxData _parryCounterAttack;
    [SerializeField]
    HitboxData _dashAttack;

    AnimatorController _anim;

    private void Start()
    {   
        _anim = GetComponent<AnimatorController>();
    }

    public void ParryAttack()
    {
        HitEnemies(_parryCounterAttack);

        //reproducirAnimacion

        #region enemyDamage
        foreach (Collider2D enemy in enemiesReached)
        {
            enemy.gameObject.GetComponent<HealthHandler>().TakeDamage(_parryCounterAttack.Damage, _parryCounterAttack.HitstopTime);
            //Hacer daño a enemigos
        }
        #endregion

        Debug.Log(enemiesReached.Length != 0);
    }

    public void PerformParryAttack()
    {
        _anim.ParryCounter(true);
    }

    public void DashAttack()
    {
        HitEnemies(_dashAttack);

        //reproducirAnimacion

        #region enemyDamage
        foreach (Collider2D enemy in enemiesReached)
        {
            enemy.gameObject.GetComponent<HealthHandler>().TakeDamage(_dashAttack.Damage, _dashAttack.HitstopTime);
            //Hacer daño a enemigos
        }
        #endregion

        Debug.Log(enemiesReached.Length != 0);
    }



}