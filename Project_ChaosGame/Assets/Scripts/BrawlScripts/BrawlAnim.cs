using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlAnim : MonoBehaviour
{
    public Animator anim;
    private int brawlMoveAnimID;
    private int lightAttackAnimID;
    private int heavyAttackAnimID;
    private int heavyFinisherAnimID;
    private int lightFinisherAnimID;
    private int deadAnimID;
    public float exitTime = 0.4f;
    BrawlMove move;
    bool setUp = false;
    // Start is called before the first frame update
    void Start()
    {

        SetupAnimationIDs();
        move = GetComponent<BrawlMove>();
       // anim = GetComponent<Animator>();
    }
    void SetupAnimationIDs()
    {
        brawlMoveAnimID = Animator.StringToHash("forwardSpeed");
        deadAnimID = Animator.StringToHash("Death");
    }
    private void Update()
    {
        if (!setUp)
        {
            SetupAnimationIDs();
        }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
        {
            //move.canMove = false;
            move.FadeMoveSpeedOut();
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= exitTime)
            {
                // move.canMove = true;
                move.FadeMoveSpeedIn();
            }
        }
        else
        {
            move.FadeMoveSpeedIn();
        }
    }
    public void PlayDeathAnim()
    {
        anim.Play(deadAnimID, 0);

    }
    public void PlayDodgeAnim()
    {
        anim.CrossFade("DodgeRoll 1", 0f, 0);
    }
    public void PlayLightAttackAnim()
    {
        anim.SetTrigger("lightAttack");
    }
    public void PlayHeavyAttackAnim()
    {
        anim.SetTrigger("heavyAttack");
    }

    public void PlayLightFinisherAnim()
    {

    }
    public void PlayHeavyFinisherAnim()
    {

    }

    public void UpdateMovementAnimation(float movementBlendValue)
    {
        anim.SetFloat(brawlMoveAnimID, movementBlendValue);
    }
}
