using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAttack")]
public class EnemyAttackScriptableObject : ScriptableObject
{
    public int damage = 10;
    public float range = 20f;
}
