using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoColliderComponent : MonoBehaviour
{
    #region references 
    [SerializeField]
    private Collider2D wall;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy)
        {
            wall.enabled = false;
        }
    }
    
    #endregion
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy)
        {
            wall.enabled=false;
            wall.enabled = true;
        }
    }
}
