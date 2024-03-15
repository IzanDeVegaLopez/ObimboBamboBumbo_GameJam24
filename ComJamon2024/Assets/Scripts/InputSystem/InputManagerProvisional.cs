using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerProvisional : MonoBehaviour
{
    CharacterMovement _chM;

    //private float xInput;

    void Start()
    {
        _chM = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) _chM.JumpPressed();
        if(Input.GetButtonUp("Jump")) _chM.JumpReleased();
        if (Input.GetButtonDown("Dash")) _chM.DashPressed();
    }


    void FixedUpdate()
    {
        _chM.SetXInput(Input.GetAxisRaw("Horizontal"));
        _chM.SetYInput(Input.GetAxisRaw("Vertical"));
    }
}
