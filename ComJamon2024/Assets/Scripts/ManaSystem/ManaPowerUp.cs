using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPowerUp : MonoBehaviour
{
    [SerializeField] ManaManager _manaManager;
    [SerializeField] int _manaToAdd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterMovement>() != null)
        {
            if (_manaManager.maxMana - _manaManager.currentMana > _manaToAdd)
            {
                _manaManager.currentMana += _manaToAdd;
                Destroy(gameObject);
            }
            else if (_manaManager.maxMana > _manaManager.currentMana)
            {
                _manaManager.currentMana = _manaManager.maxMana;
                Destroy(gameObject);
            }
        }
    }
}
