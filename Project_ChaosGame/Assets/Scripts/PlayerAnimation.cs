using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Component References")]
    public Animator playerAnimator;

    //Animation String IDs
    private int playerMovementAnimationID;
    private int playerAttackAnimationID;
    private int playerDodgeAnimID;
    private int playerJumpAnimID;
    private int playerExitAnimID;

    public void SetupBehaviour()
    {
        SetupAnimationIDs();
    }

    private void Update()
    {
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
        playerAttackAnimationID = Animator.StringToHash("attack");
        playerDodgeAnimID = Animator.StringToHash("dodge");
        playerJumpAnimID = Animator.StringToHash("jump");
        playerExitAnimID = Animator.StringToHash("exit");
    }

    public void UpdateMovementAnimation(float movementBlendValue)
    {

        playerAnimator.SetFloat(playerMovementAnimationID, movementBlendValue);
    }

    public void ExitAnim()
    {
        playerAnimator.SetTrigger(playerExitAnimID);
    }
    public void PlayAttackAnimation()
    {
        playerAnimator.SetTrigger(playerAttackAnimationID);
    }

    public void PlayDodgeAnimation()
    {

        playerAnimator.SetTrigger(playerDodgeAnimID);
    }
    public void PlayJumpAnimation()
    {

        playerAnimator.SetTrigger(playerJumpAnimID);
    }
}
