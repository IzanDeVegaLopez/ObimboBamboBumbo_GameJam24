using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region references
    [SerializeField]
    private MovementData _md;
    private Rigidbody2D _rb;
    private Transform _myTransform;
    #endregion

    #region parameters
    float moveInputX;
    #endregion

    #region hiddenVariables
    bool isJumping = false;
    bool jumpInputReleased = true;

    #region Timers
    float lastGroundedTime;
    float lastJumpTime;
    #endregion

    #endregion

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _myTransform = transform;
    }

    void FixedUpdate()
    {
        #region Checks
        if(Physics2D.OverlapBox(_myTransform.position + _md.groundCheckOffset, _md.groundCheckSize, 0, _md.groundMask))
        {
            lastGroundedTime = _md.jumpCoyoteTime;
            isJumping = false;
        }
        #endregion

        if(lastGroundedTime > 0 && lastJumpTime > 0 && !isJumping)
        {
            Jump();
        }

        Run();

        #region timers
        lastGroundedTime -= Time.fixedDeltaTime;
        lastJumpTime -= Time.fixedDeltaTime;
        #endregion
    }


    #region ownMethods
    void Run()
    {
        float targetSpeed = moveInputX * _md.moveSpeed;

        float speedDif = targetSpeed - _rb.velocity.x;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _md.acceleration : _md.decceleration;

        float movement = Mathf.Abs(speedDif) * accelRate * Mathf.Sign(speedDif);

        _rb.AddForce(movement * Vector2.right);
    }

    void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _md.jumpForce, ForceMode2D.Impulse);
        lastGroundedTime = 0;
        lastJumpTime = 0;
        isJumping = true;
        jumpInputReleased = false;
    }


    #endregion

    #region InputCallbackMethods
    public void SetXInput(float input)
    {
        moveInputX = input;
    }

    public void JumpPressed()
    {
        //Jump();

        lastJumpTime = _md.JumpBufferTime;
    }


    #endregion


    #region EDITOR METHODS
    /// <summary>
    /// draws Gizmos showing character ground hitbox
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((Vector2)(transform.position + _md.groundCheckOffset), _md.groundCheckSize);

        //Gizmos.color = Color.red;
        //Gizmos.DrawWireCube((Vector2)transform.position + (_md.yGroundCheckOffSet - _md.minPogoHeight / 2) * Vector2.up, new Vector2(_md.groundCheckSize.x, _md.minPogoHeight));
    }

    #endregion

}
