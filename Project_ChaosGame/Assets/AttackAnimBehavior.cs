using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimBehavior : StateMachineBehaviour
{

    public float damage = 5f;
    public float turnOnColliderTime = 0.3f;
    public float turnOffColliderTime = 0.45f;
    KirkFu fight;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        fight = animator.gameObject.GetComponent<KirkFu>();
        fight.SetCurrentDamage(damage);
        fight.hasHit = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!fight.hasHit)
        {
            fight.TurnColliderOnForSeconds(turnOnColliderTime, turnOffColliderTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
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
