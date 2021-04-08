using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimBehavior : StateMachineBehaviour
{

    public BrawlAttackScriptObj myAttack;
    BrawlController control;
    KirkFu fight;
    Transform playerTransform;
    bool hasSpawnedEffect = false;
    public bool effect = false;
    public bool effectChill = false;
    bool audioHasPlayed = false;

    public int finisherVFXIndex = 1;
    public int autoAttackVFXIndex = 2;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetKirkFuAndSetDamage(animator);
        ResetBools();
    }

    private void GetKirkFuAndSetDamage(Animator animator)
    {
        control = animator.gameObject.GetComponent<BrawlController>();
        fight = animator.gameObject.GetComponent<KirkFu>();
        fight.SetCurrentDamage(myAttack);
    }

    private void ResetBools()
    {

        audioHasPlayed = false;
        hasSpawnedEffect = false;
        fight.hasHit = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = animator.gameObject.transform;

        if (!fight.hasHit)
        {
            fight.TurnColliderOnForSeconds(myAttack.turnOnColliderTime, myAttack.turnOffColliderTime);
        }
        if (!audioHasPlayed && fight.hasHit)
        {
            fight.PlayImpactSound();
            audioHasPlayed = true;
        }

        if (!hasSpawnedEffect && fight.hasHit)
        {
            if (effectChill)
            {
                SpawnEffect(autoAttackVFXIndex);
            }
            if (effect)
            {
                SpawnEffect(finisherVFXIndex);

            }
        }
    }

    private void SpawnEffect(int myIndex)
    {
        GameObject clone = Instantiate(control.GetCharacter().attackEffects[myIndex], playerTransform.GetChild(6).position, playerTransform.rotation);
        Destroy(clone, 2f);
        hasSpawnedEffect = true;
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
