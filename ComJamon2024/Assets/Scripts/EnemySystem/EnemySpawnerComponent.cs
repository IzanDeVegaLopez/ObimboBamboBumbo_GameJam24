using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerComponent : MonoBehaviour
{
    #region parameters
    //corrutinas
    private float elapsedTime = 0f;
    [SerializeField]
    private float spawnTime = 1f;
    #endregion

    #region references
    [SerializeField]
    private Transform _spawnTransform;
    //Enemigo a clonar, luego se cambia por un array o lista
    [SerializeField]
    private List<GameObject> _enemy;
    
    private WaveHandler _waveHandler;
    #endregion
    #region methods
    private void SpawnEnemy()
    {
        //int i = Random.Range(0, _enemy.Count);
        Debug.Log("Spawning");
        GameObject enemy = Instantiate(_enemy[0], _spawnTransform.position, transform.rotation);
        _waveHandler.RegisterEnemy(enemy);

    }
    #endregion
    private void Start()
    {
        _waveHandler = FindObjectOfType<WaveHandler>();
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > spawnTime)
        {
            Debug.Log("spawn");
            SpawnEnemy();
            elapsedTime = 0f;
        }
    }
}
