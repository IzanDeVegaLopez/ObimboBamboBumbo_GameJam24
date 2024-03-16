using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerComponent : MonoBehaviour
{
    //corrutinas
    private float elapsedTime = 0f;
    [SerializeField]
    private float spawnTime = 1f;

    #region references
    [SerializeField]
    private Transform _spawnTransform;
    //Enemigo a clonar, luego se cambia por un array o lista
    [SerializeField]
    private List<GameObject> _enemy;


    
    #endregion
    #region methods
    public void SpawnEnemy()
    {
        if (HordeManager.Instance.totalEnemies < HordeManager.Instance.nMaxEnemies && WaveHandler.Instance.nEnemy < WaveHandler.Instance.nPerWave)
        {
            //int i = Random.Range(0, _enemy.Count);
            GameObject enemy = Instantiate(_enemy[0], _spawnTransform.position, transform.rotation);
            WaveHandler.Instance.RegisterEnemy(enemy);
        }
        

    }
    #endregion
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > spawnTime)
        {
           SpawnEnemy();
            elapsedTime = 0f;
        }
        
    }
}
