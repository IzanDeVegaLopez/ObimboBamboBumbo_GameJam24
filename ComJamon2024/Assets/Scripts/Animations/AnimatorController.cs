using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator _effectAnimator;
    private Transform _effectTransform;

    [SerializeField]
    Vector2 offset;

    private Animator _anim;
    private SpriteRenderer _spriteRenderer;

    Vector3 _originalScale;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _effectTransform = _effectAnimator.transform;
        _originalScale = _effectTransform.localScale;
    }

    private void FixedUpdate()
    {
        _spriteRenderer.flipX = (CharacterMovement.Direction == -1);
        // Debug.Log(_spriteRenderer.flipX);
    }

    public void ParryCounter(bool val)
    {
        _anim.SetBool("ParryCounter", val);
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

    public void PlayCutEffect()
    {
        _effectTransform.position = transform.position + Vector3.up * offset.x + Vector3.right * offset.x * CharacterMovement.Direction;
        _effectTransform.localScale = new Vector3(_originalScale.x * CharacterMovement.Direction, _originalScale.y, _originalScale.z); ;
        _effectAnimator.SetTrigger("DoEffect");
    }
}
