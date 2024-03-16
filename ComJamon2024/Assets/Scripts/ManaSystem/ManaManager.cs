using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ManaManager", order = 11)]
public class ManaManager : ScriptableObject
{
    public readonly int maxMana = 100;
    public int currentMana = 100;
}
