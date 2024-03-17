using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUp : MonoBehaviour
{
    [SerializeField]
    private float distance;

    void Start()
    {
        transform.position += Vector3.up * distance;
    }

}
