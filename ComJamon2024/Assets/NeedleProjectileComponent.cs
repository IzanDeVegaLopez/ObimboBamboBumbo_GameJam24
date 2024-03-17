using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NeedleProjectileComponent : MonoBehaviour
{
    [SerializeField]
    int damage = 2;
    float hitstop = 0.06f;

    float _timeSinceSpawn;

    [SerializeField] 
    float _maxDistance = 10f;
    [SerializeField]
    float _totalTime = 1f;

    float initDirection = 1;

    Transform _myTransform;
    Vector3 originalPos;

    ProjectileAbility _pA;

    [SerializeField]
    LayerMask _enemyLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (_enemyLayer == (_enemyLayer|(1<< other.gameObject.layer)))
        {
            other.gameObject.GetComponent<HealthHandler>().TakeDamage(damage, hitstop);
        }
    }

    private void Start()
    {
        initDirection = CharacterMovement.Direction;
        _myTransform = transform;
        originalPos = _myTransform.position;
        _timeSinceSpawn = Time.time;

    }

    private void FixedUpdate()
    {
        if (Time.time - _timeSinceSpawn > _totalTime)
        {
            _pA.Finished();
            Destroy(this.gameObject);
        }

        _myTransform.position = Vector3.Lerp(originalPos, originalPos + _maxDistance * Vector3.right * initDirection, Mathf.Sin((Mathf.PI *( (Time.time - _timeSinceSpawn) / _totalTime))));
    }

    public void GetReferenceToProjectileAbility(ProjectileAbility pA)
    {
        _pA = pA;
    }
}
