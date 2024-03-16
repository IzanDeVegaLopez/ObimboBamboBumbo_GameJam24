using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] AbilityData ability;

    public AbilityData aData
    {
        get => ability; 
    }

    public void UseAbility()
    {
        ability.ExecuteAbility(this);
    }
}
