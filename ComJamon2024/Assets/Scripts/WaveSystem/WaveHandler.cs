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

    //corrutinas
    private float elapsedTime = 0f;
    [SerializeField]
    private float spawnTime = 1f;
    #endregion

    #region references
    public List<GameObject> enemies = new List<GameObject>();
    private HordeManager hordeManager;
    private EnemySpawnerComponent enemySpawner;
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
        enemies.Remove(enemies[nEnemy-1]);
        nEnemy--;
        hordeManager.AddKilledEnemy();
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        hordeManager = GetComponent<HordeManager>();
        enemySpawner = FindObjectOfType<EnemySpawnerComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nEnemy > nPerWave)
        {
            ReleaseEnemy();
        }
        else
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime < spawnTime)
            {
                enemySpawner.SpawnEnemy();
            }
            else
            {
                elapsedTime = 0f;
            }
        }
    }
}
