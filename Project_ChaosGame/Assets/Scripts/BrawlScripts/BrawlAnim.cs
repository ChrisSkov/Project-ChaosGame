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
    // Start is called before the first frame update
    void Start()
    {
        SetupAnimationIDs();
        // anim = GetComponent<Animator>();
    }
    void SetupAnimationIDs()
    {
        brawlMoveAnimID = Animator.StringToHash("forwardSpeed");
        deadAnimID = Animator.StringToHash("Death");
        
        
    }
    private void Update() {
        
    }
    public void PlayDeathAnim()
    {
        anim.Play(deadAnimID,0);
    }
    public void PlayDodgeAnim()
    {
        anim.CrossFade("DodgeRoll 1", 0f,0);
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
