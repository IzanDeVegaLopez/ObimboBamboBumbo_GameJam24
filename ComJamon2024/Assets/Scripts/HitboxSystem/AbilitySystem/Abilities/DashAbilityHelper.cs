using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbilityHelper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyController enemy))
        {
            enemy._state = EnemyController.states.stun;
            enemy.GetComponent<HealthHandler>().TakeDamage(1);
        }
    }

    private void Start()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(1);
        Destroy(gameObject);
    }
}
