using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ESTO ES SOLO PARA PROBAR QUE FUNCIONA EL KB

public class probarKB : MonoBehaviour
{
    private KnockbackComponent _kb;
    public bool call;

    void Start()
    {
        _kb = GetComponent<KnockbackComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(call)
        {
            _kb.TakeKnockback(Vector3.right);
            call = false;
        }
    }
}
