using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitboxHandler : MonoBehaviour
{
    private Collider2D[] _enemiesReached;
    public Collider2D[] enemiesReached {get => _enemiesReached; }

    private Collider2D _playerReached;
    public Collider2D playerReached { get => _playerReached; }

    private HitboxData _hitboxData;

    //Debug variable
    bool _isPlayer = false;
    //mondongo
    public void HitEnemies(HitboxData hData)
    {
        _isPlayer = true;
        _hitboxData = hData;
        _enemiesReached = Physics2D.OverlapBoxAll(transform.position + (CharacterMovement.Direction * hData.HitboxPosition.x * Vector3.right + hData.HitboxPosition.y * Vector3.up), hData.HitboxSize, hData.ExtraVariable, hData.TargetLayerMask);
    }
    public void HitPlayer(HitboxData hitboxData)
    {
        _isPlayer = false;
        _hitboxData = hitboxData;
        _playerReached = Physics2D.OverlapBox(transform.position + (hitboxData.HitboxPosition.x * Vector3.right * EnemyController.Dir + hitboxData.HitboxPosition.y * Vector3.up), hitboxData.HitboxSize, hitboxData.ExtraVariable, hitboxData.TargetLayerMask);
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying || _hitboxData==null) return;
        Gizmos.color = Color.red;
        if (!_isPlayer)
            Gizmos.DrawWireCube((Vector2)(transform.position + (_hitboxData.HitboxPosition.x * Vector3.right * EnemyController.Dir + _hitboxData.HitboxPosition.y * Vector3.up)), _hitboxData.HitboxSize);
        else
            Gizmos.DrawWireCube(transform.position + (CharacterMovement.Direction * _hitboxData.HitboxPosition.x * Vector3.right + _hitboxData.HitboxPosition.y * Vector3.up), _hitboxData.HitboxSize);

    }

}
