using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", order = 1)]
public abstract class AbilityData : ScriptableObject
{
    public float castingTime = 0f; //Se usa en caso de que una habilidad tenga tiempo de uso como la de lanzar y recoger o curar vida
    public abstract void ExecuteAbility();
}
