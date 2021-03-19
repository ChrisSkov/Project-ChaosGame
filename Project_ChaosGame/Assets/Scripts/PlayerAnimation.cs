using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Component References")]
    public Animator playerAnimator;

    //Animation String IDs
    private int playerMovementAnimationID;
    private int dodgeAnimID;
    private int jumpAnimID;
    private int playerExitAnimID;
    private int deathAnimID;
    private int throwAnimID;
    private int throwVictimID;
    private int atk_1AnimID;
    private int atk_2AnimID;
    private int blockStartAnimID;
    private int blockEndAnimID;
    private int impactAnimID;
    private int blockImpactAnimID;
    private int hitBackAnimID;
    private int flexAnimID;
    private int atk_3AnimID;
    private int chargeAnimID;
    Health hp;
    public void SetupBehaviour()
    {
        hp = GetComponent<Health>();
        SetupAnimationIDs();
    }

    private void Update()
    {
        if (hp.dead)
        {
            return;
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("jump"))
        {
            playerAnimator.updateMode = AnimatorUpdateMode.AnimatePhysics;

        }
        else
        {
            playerAnimator.updateMode = AnimatorUpdateMode.Normal;
        }
    }
    void SetupAnimationIDs()
    {
        playerMovementAnimationID = Animator.StringToHash("forwardSpeed");
        atk_1AnimID = Animator.StringToHash("Atk_1");
        atk_2AnimID = Animator.StringToHash("Atk_2");
        throwAnimID = Animator.StringToHash("Throw");
        throwVictimID = Animator.StringToHash("Throw_Victim");
        dodgeAnimID = Animator.StringToHash("Roll");
        jumpAnimID = Animator.StringToHash("Jump");
        playerExitAnimID = Animator.StringToHash("exit");
        deathAnimID = Animator.StringToHash("Death");
        blockStartAnimID = Animator.StringToHash("BlockStart");
        blockEndAnimID = Animator.StringToHash("BlockEnd");
        blockImpactAnimID = Animator.StringToHash("BlockImpact");
        impactAnimID = Animator.StringToHash("TakeDMG");
        hitBackAnimID = Animator.StringToHash("HitBack");
        flexAnimID = Animator.StringToHash("Flex");
        atk_3AnimID = Animator.StringToHash("Atk_3");
        chargeAnimID = Animator.StringToHash("Charge");
    }

    public void PlayChargeAnim()
    {
        playerAnimator.Play(chargeAnimID, 0);
    }

    public void PlayFlexAnim()
    {
        playerAnimator.Play(flexAnimID, 0);
    }
    public void UpdateMovementAnimation(float movementBlendValue)
    {

        playerAnimator.SetFloat(playerMovementAnimationID, movementBlendValue);
    }

    public void PlayHitBackAnim()
    {
        playerAnimator.Play(hitBackAnimID, 0);
    }

    public void PlayIsThrownAnim()
    {
        playerAnimator.Play(throwVictimID);
        // playerAnimator.SetTrigger(playerIsThrownAnimID);
    }

    public void PlayThrowAnim()
    {
        // if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("BlockImpact"))
        // {
        //         }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion") && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Throw_Victim"))
        {
            playerAnimator.Play(throwAnimID);
        }

    }
    public void ExitAnim()
    {
        playerAnimator.SetTrigger(playerExitAnimID);
    }
    public void PlayAttackAnimation(int atkCount, bool canAttack)
    {
        if (canAttack)
        {
            playerAnimator.SetTrigger("attack");
        }
        else
        {
            return;
        }
        // if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
        // {
        //     if (atkCount == 0 && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Atk_1"))
        //     {

        //         //playerAnimator.Play(atk_1AnimID, 0);
        //     }
        //     else if (atkCount == 1 && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Atk_2"))
        //     {
        //         playerAnimator.SetTrigger("attack");

        //         //playerAnimator.Play(atk_2AnimID, 0);

        //     }
        // }
        //    

        //         // else if (atkCount == 2)
        //         // {
        //         //     playerAnimator.Play(atk_3AnimID, 0);
        //         // }
        //     }
        //     //playerAnimator.SetTrigger(playerAttackAnimationID);
    }

    public void PlayDeathAnimation()
    {
        playerAnimator.Play(deathAnimID, 0);
    }
    public void PlayDodgeAnimation()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
        {
            playerAnimator.Play(dodgeAnimID, 0);
        }
    }
    public void PlayJumpAnimation()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
        {
            playerAnimator.Play(jumpAnimID, 0);
        }
    }

    public void PlayBlockStartAnim()
    {

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
        {
            playerAnimator.Play(blockStartAnimID, 0);
        }
    }
    public void PlayBlockImpactAnim()
    {
        if (hp.dead)
            return;
        playerAnimator.Play(blockImpactAnimID, 0);

    }

    public void PlayTakeDamage()
    {
        if (hp.dead)
            return;
        playerAnimator.Play(impactAnimID, 0);
    }


}
