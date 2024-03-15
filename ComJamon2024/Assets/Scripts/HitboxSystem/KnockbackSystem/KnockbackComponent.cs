using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackComponent : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField]
    private KnockbackData _kd;

    public void TakeKnockback(Vector3 dir)
    {
        _rb.AddForce(new Vector3(dir.x, 0).normalized * _kd.knockbackForce, ForceMode2D.Impulse);
    }


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

}
