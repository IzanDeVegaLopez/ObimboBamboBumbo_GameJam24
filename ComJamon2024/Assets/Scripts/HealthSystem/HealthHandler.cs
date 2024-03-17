using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    private AbilityAttack _abilityAttack;

    private SpriteRenderer _sR;
    
    [SerializeField] private int _maxHealth = 5;
    public int maxHealth { get => _maxHealth; }
    [SerializeField]
    private int _currentHealth = 3;
    public int currentHealth { get => _currentHealth; }

    [SerializeField]
    private bool _blocking = false;

    private GameObject _myGameObject;
    public UnityEvent onTakeDamage = new UnityEvent();
    public UnityEvent onHeal = new UnityEvent();
    public UnityEvent OnDeath = new UnityEvent();

    [SerializeField]
    ManaManager _manaManager;
    [SerializeField]
    int manaGivenOnDeath = 5;
    private void Start()
    {
        _abilityAttack = GetComponent<AbilityAttack>();
        _myGameObject = gameObject;
        _sR = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int damage, float timeStop)
    {

        //Debug.Log(damage);
        if (!_blocking)
        {
            _currentHealth -= damage;

            Hitstop.Instance.Stop(timeStop);

            if (_currentHealth <= 0)
            {
                _manaManager.currentMana += manaGivenOnDeath;
                StopAllCoroutines();
                Death();
            }
            StartCoroutine(parpadeo());
            onTakeDamage?.Invoke();
        }
        else
        {
            SetBlock(false);
            _abilityAttack.PerformParryAttack();
        }
    }

    IEnumerator parpadeo()
    {
        for(int i= 0; i < 2; i++)
        {
            _sR.color = Color.red;
            yield return new WaitForSecondsRealtime(0.2f);
            _sR.color = Color.white;
            yield return new WaitForSecondsRealtime(0.2f);
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
