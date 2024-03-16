using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _spriteRenderer.flipX = (CharacterMovement.Direction == -1);
        // Debug.Log(_spriteRenderer.flipX);
    }

    public void StartAttackAnim(int i)
    {
        _anim.SetInteger("AttackIndex", i);
    }

    public void AttackFinished()
    {
        _anim.SetInteger("AttackIndex", 5);
    }

    public void SetWalking(bool val)
    {
        _anim.SetBool("Walking", val);
    }
}
