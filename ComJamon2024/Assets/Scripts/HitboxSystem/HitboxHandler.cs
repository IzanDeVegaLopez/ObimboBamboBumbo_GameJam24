using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitboxHandler : MonoBehaviour
{
    private Collider2D[] _enemiesReached;
    public Collider2D[] enemiesReached {get => _enemiesReached; }
    private HitboxData _hitboxData;
    //mondongo
    public void HitEnemies(HitboxData hData)
    {
        _hitboxData = hData;
        _enemiesReached = Physics2D.OverlapBoxAll(transform.position + (CharacterMovement.Direction * hData.HitboxPosition.x * Vector3.right + hData.HitboxPosition.y * Vector3.up), hData.HitboxSize, hData.ExtraVariable, hData.TargetLayerMask);
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying || _hitboxData==null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)(transform.position + (_hitboxData.HitboxPosition.x * Vector3.right * CharacterMovement.Direction + _hitboxData.HitboxPosition.y * Vector3.up)), _hitboxData.HitboxSize);
    }

}
