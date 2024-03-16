using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropComponent : MonoBehaviour
{
    [SerializeField] GameObject[] _drops;
    [SerializeField] int[] _dropRate;
    HealthHandler _healthHandler;
    bool droped = false;

    private void Awake()
    {
        _healthHandler = GetComponent<HealthHandler>();
        _healthHandler.OnDeath.AddListener(Drop);
    }

    public void Drop()
    {
        int random = Random.Range(0, 101);
        int rate = 0;
        
        for(int i = 0; i < _drops.Length; i++)
        {
            rate += _dropRate[i];
            if(random <= rate && !droped)
            {
                Instantiate(_drops[i], transform.position, Quaternion.identity);
                droped = true;
            }
        }

    }
}
