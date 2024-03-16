using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityAttack : HitboxHandler
{
    [SerializeField]
    HitboxData _parryCounterAttack;
    [SerializeField]
    HitboxData _dashAttack;

    public void ParryAttack()
    {
        HitEnemies(_parryCounterAttack);

        //reproducirAnimacion

        #region enemyDamage
        foreach (Collider2D enemy in enemiesReached)
        {
            enemy.gameObject.GetComponent<HealthHandler>().TakeDamage(_parryCounterAttack.Damage);
            //Hacer da�o a enemigos
        }
        #endregion

        Debug.Log(enemiesReached.Length != 0);
    }

    public void DashAttack()
    {
        HitEnemies(_dashAttack);

        //reproducirAnimacion

        #region enemyDamage
        foreach (Collider2D enemy in enemiesReached)
        {
            enemy.gameObject.GetComponent<HealthHandler>().TakeDamage(_dashAttack.Damage);
            //Hacer da�o a enemigos
        }
        #endregion

        Debug.Log(enemiesReached.Length != 0);
    }



}