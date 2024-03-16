using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    #region parameters
    //número de enemigos que hay en la escena
    private int nEnemy = 0;
    [SerializeField]
    private int nPerWave = 1;
    #endregion

    #region references
    private List<GameObject> enemies = new List<GameObject>();
    private HordeManager hordeManager;
    //private EnemySpawnerComponent enemySpawner;
    #endregion
    #region methods
    public void RegisterEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
        nEnemy++;
        hordeManager.AddSpawnedEnemy();
    }
    private void ReleaseEnemy()
    {
        Destroy(enemies[nEnemy - 1]);
        enemies.Remove(enemies[nEnemy-1]);
        
        nEnemy--;
        hordeManager.AddKilledEnemy();
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        hordeManager = GetComponent<HordeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nEnemy > nPerWave)
        {
            Debug.Log("Lleno");
            ReleaseEnemy();
        }
    }
}
