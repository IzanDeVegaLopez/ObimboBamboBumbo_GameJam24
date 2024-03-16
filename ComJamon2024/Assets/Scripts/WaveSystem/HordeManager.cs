using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HordeManager : MonoBehaviour
{
    #region parameters
    
    public int nMaxEnemies = 1;
    
    public int totalEnemies = 0;
    [SerializeField]
    private int killedEnemies = 0;
    #endregion

    private static HordeManager _instance;
    public static HordeManager Instance {  get { return _instance; } }
    #region methods 
    public void AddSpawnedEnemy(int val)
    {
        if (totalEnemies < nMaxEnemies) totalEnemies+= val;
    }
    public void AddKilledEnemy()
    {
        killedEnemies++;
    }
    #endregion

    // Start is called before the first frame update
    void Awake()
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
        if (totalEnemies == nMaxEnemies && totalEnemies == killedEnemies )
        {
            Debug.Log("Acabado");
        }
    }
}
