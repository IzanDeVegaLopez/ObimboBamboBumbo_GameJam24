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
        enemies.Add(enemy);
        SetNenemies(1);
        HordeManager.Instance.AddSpawnedEnemy(1);

        if (nEnemy > nPerWave)
        {
            ReleaseEnemy(enemy);
        }
    }
    private void ReleaseEnemy(GameObject enemy)
    {
        if (enemies.Count > 0)
        {
            enemies.Remove(enemy);
            Destroy(enemy);
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

    }
}
