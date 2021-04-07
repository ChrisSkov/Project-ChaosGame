using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{

    public bool spamLightAttack = false;

    public bool spamHeavyAttack = false;
    public bool alternateLightHeavy = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spamLightAttack)
        {
            anim.SetTrigger("lightAttack");
        }
        else if (spamHeavyAttack)
        {
            anim.SetTrigger("heavyAttack");
        }
        else if(alternateLightHeavy)
        {
            anim.SetTrigger("lightAttack");
            anim.SetTrigger("heavyAttack");
        }
    }
}
