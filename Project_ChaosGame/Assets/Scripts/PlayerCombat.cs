using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{

  
    PlayerAnimation playerAnim;
    public Transform shovelTip;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();
    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            playerAnim.PlayAttackAnimation();
        }
    }


    void AttackAnimEvent()
    {
        LayerMask mask = LayerMask.GetMask("Hitable");
        foreach(Collider c in Physics.OverlapSphere(shovelTip.position, 1f,mask))
        {
            c.GetComponentInParent<BarrelHealth>().isTriggered = true;
        }
    }

}
