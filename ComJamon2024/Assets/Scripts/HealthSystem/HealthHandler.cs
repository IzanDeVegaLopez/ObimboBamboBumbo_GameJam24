using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 5;
    public int maxHealth { get => _maxHealth; }
    private int _currentHealth = 1;
    public int currentHealth { get => _currentHealth; }
    
    UnityEvent onTakeDamage = new UnityEvent();
    UnityEvent onHeal = new UnityEvent();
    UnityEvent OnDeath = new UnityEvent();
    public void TakeDamage()
    {
        _currentHealth--;
        if (_currentHealth <= 0) Death();
        onTakeDamage?.Invoke();
    }
    public void Heal()
    {
        _currentHealth++;
        onHeal?.Invoke();
    }
    public void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
