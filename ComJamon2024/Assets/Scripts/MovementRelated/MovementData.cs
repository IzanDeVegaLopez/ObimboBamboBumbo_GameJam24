using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement Data", order = 10)]
public class MovementData : ScriptableObject
{
    [Header("HorizontalMovement")]
    //max Horizontal Speed
    public float maxMoveSpeed = 1f;
    //[Range(0.0F, 1.0F)]
    public float acceleration = 1f;
    //[Range(0.0F, 1.0F)]
    public float decceleration = 1f;
    [Range(0.0F, 1.0F)]
    public float accelInAir = 1f;
    [Range(0.0F, 1.0F)]
    public float deccelInAir = 1f;
    //permite ir a mayor velocidad de la normal en la dirección de movimiento actual
    public bool doConserveMomentum;

    [Header("Pogo")]
    public float minPogoHeight = 1f;
    public float pogoXDuration = 0.1f;
    public float pogoYDuration = 0.4f;
    public float pogoFallForce = 20f;
    public float pogoInitialUpVel = 2f;
    public float pogoEmpoweredJumpDuration = 0.5f;
    public float empoweredJumpForceMultiplier = 1f;
    public Vector2 pogoSize = new Vector2(5, 10);
    public Vector2 pogoPosition = new Vector2(0, -3);

    [Header("Slide")]
    public float slideHorizontalForce = 3;
    [Range(0.0F, 1.0F)]
    public float slideSameDirectionForceMultiplier = 1;
    public float slideForceApplyThreshold = 1f;
    public float timeBetweenSlides = 1f;
    public float slideDuration = 0.5f;
    [Range(0.0F,1.0F)]
    public float slideBufferTime = 0.2f;
    //public float slideYVelMarginError = 1f;

    [Header("Jump")]
    public float jumpForce = 1f;
    //1/10 - 1/20 of a second
    public float jumpBufferTime = 0.1f;
    public float jumpCoyoteTime = 0.1f;

    [Range(0.0F, 1.0F)]
    public float jumpCutMultiplier = 0;

    [Range(1.0F, 10.0F)]
    public float jumpHangAccelerationMultiplier = 1;
    [Range(1.0F, 10.0F)]
    public float jumpHangMaxSpeedMultiplier = 1;
    [Range(0F, 1F)]
    public float jumpHangTimeThreshold = 0;
    [Range(0F, 1F)]
    public float jumpHangGravityMultiplier = 1;

    [Header("WallJump")]
    public float wjHitboxDuration = 2f;

    public Vector2 wallJumpSize = new Vector2(14, 5);
    public Vector2 wallJumpPosition = new Vector2(5, 5);
    //public float wallJump2nd
    public float xSeparationFromWallOnWallJump = 0.3f;
    public float wallJump2ndJumpForceY = 5f;
    public float wallJump2ndJumpForceX = 10f;
    public float blockMovement2ndJumpTime = 0.5f;
    //public float redirectionMargin = 0.1f;
    public int maxNumberOfWallJumps = 3;
    public Vector2 wallJumpForce = new Vector2(1, 1);
    [Range(0.0F, 1.0F)]
    public float wallJumpSameDirectionForceMultiplier = 1;
    public float wallJumpForceApplyThreshold = 1f;
    [Range(0.0F, 1.0F)]
    public float wallJumpMomentumConserveCoeficient = 0.8f;
    [Range(0.0F,1.0F)]
    public float wallJump2ForceReductionCoef = 0.6f;

    [Header("WallRun")]
    public float minWallRunSpeed = 50f;
    public float wallRunNormalDuration = 1f;
    public float wallRunIncreaseCoeficient = 2f;
    //public float gravityGain = 0.5f;

    [Header("Gravity")]
    public float gravityScale = 1;
    //mayor igual de 1
    public float fallGravityMultiplier = 1;
    public float maxFallSpeed = 10f;

    [Header("CollisionChecks")]
    public float yGroundCheckOffSet = -0.51f;
    public Vector2 groundCheckSize = new Vector2(0.45f, 0.05f);
    public LayerMask groundLayer;

}
