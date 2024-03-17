using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityIntermediate : MonoBehaviour
{
    [SerializeField] AbilitySelector abilitySelector;
    [SerializeField] int abilitySelected = 1;

    public void AbilitySelected()
    {
        Debug.Log("Selected " + gameObject.name);
        abilitySelector.abilityIndex = abilitySelected;
    }
}
