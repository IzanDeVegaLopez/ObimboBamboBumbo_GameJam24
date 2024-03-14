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
    int touchingWall = 0;
    int airJumpsLeft = 1;

    #region Timers
    float lastGroundedTime;
    float lastJumpTime;
    float lastWJtime = 10;
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
        //CheckGrounded
        if(Physics2D.OverlapBox(_myTransform.position + _md.groundCheckOffset, _md.groundCheckSize, 0, _md.groundMask))
        {
            lastGroundedTime = _md.jumpCoyoteTime;
            isJumping = false;
            airJumpsLeft = _md.totalAirJumpNumber;
        }

        //CheckTouchingWall Right
        if(moveInputX == 1 && Physics2D.OverlapBox(_myTransform.position + _md.WJCheckOffset, _md.WJCheckSize, 0, _md.groundMask))
        {
            Debug.Log(1);
            touchingWall = 1;
        }
        //Checktouching wall left
        else if (moveInputX == -1 && Physics2D.OverlapBox(_myTransform.position + _md.WJCheckOffset.x * Vector3.left + Vector3.up*_md.WJCheckOffset.y, _md.WJCheckSize, 0, _md.groundMask))
        {
            Debug.Log(-1);
            touchingWall = -1;
        }
        //Not touching wall
        else
        {
            touchingWall = 0;
        }
        #endregion

        if (((lastGroundedTime > 0 && !isJumping) || touchingWall!=0 || (isJumping &&  airJumpsLeft > 0)) && lastJumpTime > 0 )
        {
            if (touchingWall != 0 && lastGroundedTime <= 0) 
            {
                WJ(touchingWall);
                lastWJtime = 0;
            }
            else if(lastGroundedTime <= 0)
            {
                airJumpsLeft--;
            }
            Jump();
        }

        if(touchingWall != 0 && lastWJtime > _md.WJLerpDuration)
        {
            WR();
        }

        Run(lastWJtime / _md.WJLerpDuration);

        #region Jump Gravity
        if (touchingWall != 0)
        {
            _rb.gravityScale = 0;
        }
        else if (isJumping && Mathf.Abs(_rb.velocity.y) < _md.jumpHangTimeThreshold)
        {
            _rb.gravityScale = _md.gravityScale * _md.jumpHangGravityMult;
        }
        else if(_rb.velocity.y < 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Max(_rb.velocity.y, -_md.maxFallSpeed));
            _rb.gravityScale = _md.gravityScale * _md.fallGravityMultiplier;
        }
        else
        {
            _rb.gravityScale = _md.gravityScale;
        }
        #endregion

        #region timers
        lastGroundedTime -= Time.fixedDeltaTime;
        lastJumpTime -= Time.fixedDeltaTime;
        lastWJtime += Time.fixedDeltaTime;
        #endregion
    }


    #region ownMethods
    void Run(float lerpValue)
    {
        float targetSpeed = moveInputX * _md.moveSpeed;
        targetSpeed = Mathf.Lerp(_rb.velocity.x, targetSpeed, lerpValue);

        float speedDif = targetSpeed - _rb.velocity.x;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _md.acceleration : _md.decceleration;

        float movement = speedDif * accelRate;

        _rb.AddForce(movement * Vector2.right);
    }

    void WR()
    {
        float speedDif = _md.WRmoveSpeed - _rb.velocity.y;

        float movement = speedDif * _md.WRacceleration;

        _rb.AddForce(movement * Vector2.up);

        _rb.velocity = Vector2.up*Mathf.Max(_rb.velocity.y, 0);
    
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

    void WJ(int i)
    {
        _rb.velocity = new Vector2(0, 0);
        _rb.AddForce(i * Vector3.left * _md.WJxForce, ForceMode2D.Impulse);
    }


    #endregion

    #region InputCallbackMethods
    public void SetXInput(float input)
    {
        moveInputX = input;
    }

    public void JumpPressed()
    {

        lastJumpTime = _md.JumpBufferTime;
    }
    public void JumpReleased()
    {
        if (_rb.velocity.y > 0 && isJumping)
        {
            _rb.AddForce(Vector2.down * _rb.velocity.y * (1 - _md.jumpCutMultiplier), ForceMode2D.Impulse);
        }

        jumpInputReleased = true;
        lastJumpTime = 0;

        //lastJumpTime = _md.JumpBufferTime;
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
        //_myTransform.position + _md.WJCheckOffset, _md.WJCheckSize
        //_myTransform.position + _md.WJCheckOffset.x * Vector3.left + Vector3.up*_md.WJCheckOffset.y, _md.WJCheckSize
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)(_myTransform.position + _md.WJCheckOffset), _md.WJCheckSize);
        Gizmos.DrawWireCube((Vector2)(_myTransform.position + _md.WJCheckOffset.x * Vector3.left + Vector3.up * _md.WJCheckOffset.y), _md.WJCheckSize);


        //Gizmos.color = Color.red;
        //Gizmos.DrawWireCube((Vector2)transform.position + (_md.yGroundCheckOffSet - _md.minPogoHeight / 2) * Vector2.up, new Vector2(_md.groundCheckSize.x, _md.minPogoHeight));
    }

    #endregion

}
