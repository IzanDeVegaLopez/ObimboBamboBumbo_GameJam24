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
    [Range(0f, 1f)]
    public float accMultiplierAir = 1f;
    [Range(0f, 1f)]
    public float decMultiplierAir = 1f;


    [Header("Jump")]
    public float jumpForce = 20f;
    public float JumpBufferTime = 0.15f;
    public float jumpCoyoteTime = 0.2f;
    public float jumpCutMultiplier = 0.4f;

    public float gravityScale = 3f;
    public float fallGravityMultiplier = 1.5f;
    public float maxFallSpeed = 50f;
    public float jumpHangGravityMult = 0.5f;
    public float jumpHangTimeThreshold = 0.1f;

    public int totalAirJumpNumber = 1;

    [Header("WJ")]
    public Vector3 WJCheckOffset;
    public Vector3 WJCheckSize;
    public float WJxForce = 10f;
    public float WJLerpDuration;

    [Header("WR")]
    public float WRmoveSpeed = 3f;
    public float WRacceleration = 5f;

    [Header("Checks")]
    public Vector3 groundCheckOffset;
    public Vector3 groundCheckSize;
    public LayerMask groundMask;

    [Header("Dash")]
    public float dashForce;
    public float dashLerpDuration;
    public float dashCooldown = 1f;
}
