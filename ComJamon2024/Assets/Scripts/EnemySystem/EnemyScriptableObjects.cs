using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyParameteres")]
public class EnemyScriptableObjects : ScriptableObject
{
    public int health = 2;
    public float speed = 3f;
    public float range = 1f;
    //public EnemyAttackScriptableObject attackType;
}
