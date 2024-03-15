using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitboxHandler : MonoBehaviour
{
    static private Collider2D[] _enemiesReached;
    public Collider2D[] enemiesReached {get => _enemiesReached; }
    static private HitboxData _hitboxData;
    //mondongo
    static void HitEnemies()
    {
        _enemiesReached = Physics2D.OverlapBoxAll(_hitboxData.HitboxPosition, _hitboxData.HitboxSize, _hitboxData.ExtraVariable, _hitboxData.TargetLayerMask);
    }

}
