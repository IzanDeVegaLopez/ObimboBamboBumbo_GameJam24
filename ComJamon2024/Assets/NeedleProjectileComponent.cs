using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NeedleProjectileComponent : MonoBehaviour
{
    float _timeSinceSpawn;

    [SerializeField] 
    float _maxDistance = 10f;
    [SerializeField]
    float _totalTime = 1f;

    float initDirection = 1;

    Transform _myTransform;
    Vector3 originalPos;

    ProjectileAbility _pA;

    private void OnCollisionEnter(Collision collision)
    {
        //Meter aquí que haga daño a todos los enemigos con los que se encuentre
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
