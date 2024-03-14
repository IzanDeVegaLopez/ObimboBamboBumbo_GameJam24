using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement Data", order = 10)]
public class MovementData : ScriptableObject
{
    [Header("HorizontalMovement")]
    public float moveSpeed = 10f;
    public float acceleration = 10f;
    public float decceleration = 10f;


    [Header("Jump")]
    public float jumpForce = 20f;
    public float JumpBufferTime = 0.15f;
    public float jumpCoyoteTime = 0.2f;

    public Vector3 groundCheckOffset;
    public Vector3 groundCheckSize;
    public LayerMask groundMask;
}
