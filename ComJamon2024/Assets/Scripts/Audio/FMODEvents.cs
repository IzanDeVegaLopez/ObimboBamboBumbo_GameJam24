using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    #region references
    [field: Header("SFX")]
    [field: SerializeField] public EventReference test {get; private set;}
    #endregion
    #region properties
    private static FMODEvents instance;
    public static FMODEvents Instance { get { return instance; } }
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
}
