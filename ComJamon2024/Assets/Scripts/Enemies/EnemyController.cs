using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region references
    [SerializeField]
    private EnemyScriptableObjects enemy;
    [SerializeField]
    private Transform targetTransform;
    private Transform _myTransform;
    private Rigidbody2D _rb;
    //solo para testear
    private Animator _myAnimator;
    #endregion
    #region properties

    //para testear
    private float elapsedTime = 0f;
    private float elapsedTime2 = 0f;
    private float duration = 2f;
    public enum states
    {
        walk, attack, wait, stun
    }
    public states _state;
    [SerializeField] int _stunSeconds;
    #endregion

    void Start()
    {
        _myTransform = transform;
        _state = states.walk;
        _rb = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (_state != states.stun)
        {
            float distance = Mathf.Abs(_myTransform.position.x - targetTransform.position.x);
            if (_state == states.walk)
            {
                _myAnimator.SetInteger("AnimState", 0);
                //cuando estoy dentro del rango de ataque de cada enemigo, ataco
                if (distance < enemy.range)
                {
                    _rb.velocity = Vector2.zero;
                    _state = states.attack;
                }
                else
                {

                    if (_myTransform.position.x > targetTransform.position.x) _rb.velocity = Vector2.left * enemy.speed;
                    else if (_myTransform.position.x < targetTransform.position.x) _rb.velocity = Vector2.right * enemy.speed;
                    else _rb.velocity = Vector2.zero;
                }
            }
            else if (_state == states.attack)
            {
                _myAnimator.SetInteger("AnimState", 1);
                //todo esto es para probar la maquina de estado, luego se cambia
                elapsedTime += Time.fixedDeltaTime;
                if (elapsedTime > duration)
                {
                    _state = states.wait;
                    elapsedTime = 0;
                }
            }
            else
            {
                //estado de espera, PROVISIONALLLL
                _myAnimator.SetInteger("AnimState", 2);
                elapsedTime2 += Time.fixedDeltaTime;
                if (elapsedTime2 > duration / 4)
                {
                    elapsedTime2 = 0;
                    //si el target sigue dentro del range del enemigo, sigue atacando
                    if (distance < enemy.range)
                    {
                        _state = states.attack;
                    }
                    else
                    {
                        _state = states.walk;
                    }
                }


            }
        }
        else
        {
            _rb.velocity = Vector2.zero;
            _myAnimator.SetInteger("AnimState", 3);
            StartCoroutine(StunWait());
            _state = states.wait;
        }
    }

    private IEnumerator StunWait()
    {
        yield return new WaitForSecondsRealtime(_stunSeconds);
    }
}
