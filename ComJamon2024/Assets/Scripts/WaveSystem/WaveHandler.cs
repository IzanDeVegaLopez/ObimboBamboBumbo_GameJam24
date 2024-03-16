using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    #region parameters
    //número de enemigos que hay en la escena
    
    public int nEnemy = 0;
    [SerializeField]
    public int nPerWave = 1;
    #endregion

    #region references
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();
    //private EnemySpawnerComponent enemySpawner;
    #endregion

    private static WaveHandler _instance;
    public static WaveHandler Instance {  get { return _instance; } }
    #region methods
    public void SetNenemies(int val)
    {
        nEnemy += val;
    }
    public void RegisterEnemy(GameObject enemy)
    {
        Debug.Log("Register");
        enemies.Add(enemy);
        SetNenemies(1);
        HordeManager.Instance.AddSpawnedEnemy(1);
    }
    private void ReleaseEnemy()
    {
        if (enemies.Count > 0)
        {
            Destroy(enemies[nEnemy - 1]);
            enemies.Remove(enemies[nEnemy - 1]);
            SetNenemies(-1);
            HordeManager.Instance.AddSpawnedEnemy(-1);
        }
    }

    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(_instance);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (nEnemy > nPerWave)
        {
            ReleaseEnemy();
        }
    }
}
