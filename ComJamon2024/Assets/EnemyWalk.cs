using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : StateMachineBehaviour
{
    #region parameters
    //Condición para pasar al estado de ataque
    [SerializeField]
    private float distance = 1.0f;
    #endregion

    #region references
    [SerializeField]
    private EnemyScriptableObjects enemy;
    private Transform myTransform;
    [SerializeField]
    private GameObject target;
    private Rigidbody2D myRB2D;
    #endregion

    #region properties
    Vector2 moveDirection;
    #endregion

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        myTransform=animator.transform;
        myRB2D = animator.GetComponent<Rigidbody2D>();
        //calculo el vector de distancia entre el enemigo y el jugador
        Vector2 distance = myTransform.position - target.transform.position;
        if (distance.x > 0) moveDirection = Vector2.left;
        else moveDirection = Vector2.right;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (distance-enemy.range > 0.1f)
        {

            animator.SetInteger("AnimState", 1);
        }
        else myRB2D.velocity = moveDirection * enemy.speed;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
