using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HordeManager : MonoBehaviour
{
    public UnityEvent onHordeFinished = new UnityEvent();
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

        if (totalEnemies == nMaxEnemies && totalEnemies == killedEnemies)
        {
            onHordeFinished?.Invoke();
        }
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
}
