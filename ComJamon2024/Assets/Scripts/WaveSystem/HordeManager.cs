using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int nMaxEnemies = 1;
    private int totalEnemies = 0;
    private int killedEnemies = 0;
    #endregion

    #region methods 
    public void AddSpawnedEnemy()
    {
        totalEnemies++;
    }
    public void AddKilledEnemy()
    {
        killedEnemies++;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalEnemies == nMaxEnemies && totalEnemies == killedEnemies )
        {
            //Evento de fin de horda
        }
    }
}
