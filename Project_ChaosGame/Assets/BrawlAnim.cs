using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlAnim : MonoBehaviour
{
    private int brawlMoveAnimID;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMovementAnimation(float movementBlendValue)
    {

        anim.SetFloat(brawlMoveAnimID, movementBlendValue);
    }
}
