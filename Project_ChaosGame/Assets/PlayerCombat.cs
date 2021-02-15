using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
 
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            anim.SetTrigger("attack");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
