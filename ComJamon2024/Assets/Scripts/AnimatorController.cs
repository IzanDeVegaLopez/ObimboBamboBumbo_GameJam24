using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void StartAttackAnim(int i)
    {
        _anim.SetInteger("AttackIndex", i);
    }

    public void AttackFinished()
    {
        _anim.SetInteger("AttackIndex", 5);
    }
}
