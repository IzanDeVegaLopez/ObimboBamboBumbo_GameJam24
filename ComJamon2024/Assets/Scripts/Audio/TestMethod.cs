using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMethod : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterMovement player =collision.gameObject.GetComponent<CharacterMovement>();
        if (player != null)
        {
            AudioManager.Instance.PlayOneShot(FMODEvents.Instance.test, transform.position);
            Destroy(gameObject);
        }
    }
}
