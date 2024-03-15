using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitboxHandler : MonoBehaviour
{
    private Collider2D[] _enemiesReached;
    public Collider2D[] enemiesReached {get => _enemiesReached; }
    [SerializeField] private HitboxData _hitboxData;
    //mondongo
    public void HitEnemies(HitboxData hData)
    {
        _enemiesReached = Physics2D.OverlapBoxAll(hData.HitboxPosition, hData.HitboxSize, hData.ExtraVariable, hData.TargetLayerMask);
    }

}
