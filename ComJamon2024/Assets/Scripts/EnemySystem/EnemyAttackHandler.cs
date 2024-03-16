using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackHandler : HitboxHandler
{
    #region references
    private EnemyController _controller;
    [SerializeField]
    private HitboxData _enemyHitbox;
    #endregion

    #region methods
    public void EnemyAttacks()
    {
        HitPlayer(_enemyHitbox);
        if (playerReached != null)
        {
            Debug.Log("HIt");
            //Hacer daño al jugador
        }
    }
    #endregion

    void Start()
    {
        _controller = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
