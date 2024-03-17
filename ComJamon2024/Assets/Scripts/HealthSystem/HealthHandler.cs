using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    private AbilityAttack _abilityAttack;
    
    [SerializeField] private int _maxHealth = 5;
    public int maxHealth { get => _maxHealth; }
    [SerializeField]
    private int _currentHealth = 3;
    public int currentHealth { get => _currentHealth; }

    private bool _blocking = false;

    private GameObject _myGameObject;
    public UnityEvent onTakeDamage = new UnityEvent();
    public UnityEvent onHeal = new UnityEvent();
    public UnityEvent OnDeath = new UnityEvent();
    private void Start()
    {
        _abilityAttack = GetComponent<AbilityAttack>();
        _myGameObject = gameObject;
    }
    public void TakeDamage(int damage, float timeStop)
    {

        //Debug.Log(damage);
        if (!_blocking)
        {
            _currentHealth -= damage;

            Hitstop.Instance.Stop(timeStop);

            if (_currentHealth <= 0) Death();
            onTakeDamage?.Invoke();
        }
        else
        {
            SetBlock(false);
            _abilityAttack.ParryAttack();
        }
    }
    public void Heal()
    {
        _currentHealth++;
        onHeal?.Invoke();
    }
    public void Death()
    {
        OnDeath?.Invoke();
        if (_myGameObject.GetComponent<EnemyController>() != null)
        {
            HordeManager.Instance.AddKilledEnemy();
            WaveHandler.Instance.SetNenemies(-1);
        }
        Destroy(gameObject);
    }

    public void SetBlock(bool val)
    {
        _blocking = val;
    }
}
