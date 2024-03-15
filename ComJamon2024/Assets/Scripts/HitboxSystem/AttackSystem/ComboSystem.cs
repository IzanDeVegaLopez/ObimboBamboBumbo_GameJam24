using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : HitboxHandler
{
    [SerializeField]
    HitboxData[] _groundedAttack = new HitboxData[4];
    [SerializeField]
    private ComboStates _currentComboState;

    public ComboStates currentComboState { get => _currentComboState; }

    public bool Attack()
    {
        //Check enemies hit
        HitEnemies(_groundedAttack[(int)_currentComboState]);

        #region enemyDamage
        //Hacer daño a los enemigos
        foreach (Collider2D enemy in enemiesReached)
        {
            //enemy.gameObject.GetComponent<>().DealDamage;
            
            enemy.GetComponent<KnockbackComponent>().TakeKnockback(enemy.transform.position - transform.position);
        }
        #endregion 

        
        //Cambiar estado
        if ((int)_currentComboState != 3)
        {
            _currentComboState = (ComboStates)((int)_currentComboState + 1);
        }
        else
        {
            _currentComboState = (ComboStates)0;
        }
        
        return enemiesReached.Length != 0;
    }

    public void resetComboState()
    {
        _currentComboState = ComboStates.slash1;
    }
}

public enum ComboStates
{
    slash1 = 0,
    slash2 = 1, 
    slash3 = 2, 
    finisher = 3
}