using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    #region references
    private EnemyController _controller;
    #endregion



    void Start()
    {
        _controller = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
