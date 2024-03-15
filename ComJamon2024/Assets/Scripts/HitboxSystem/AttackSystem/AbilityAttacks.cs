using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityAttack : HitboxHandler
{
    [SerializeField]
    HitboxData _parryCounterAttack;

    public void ParryAttack()
    {
        HitEnemies(_parryCounterAttack);

        //reproducirAnimacion

        #region enemyDamage
        foreach (Collider2D enemy in enemiesReached)
        {
            //Hacer daño a enemigos
        }
        #endregion

        Debug.Log(enemiesReached.Length != 0);
    }



}