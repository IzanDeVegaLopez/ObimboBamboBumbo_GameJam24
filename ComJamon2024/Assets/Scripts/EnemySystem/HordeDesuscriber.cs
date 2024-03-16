using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeDesuscriber : MonoBehaviour
{
    public void Desuscribe()
    {
        HordeManager.Instance.AddKilledEnemy();
    }
}
