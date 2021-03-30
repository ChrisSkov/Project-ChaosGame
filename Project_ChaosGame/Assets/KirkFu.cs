using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirkFu : MonoBehaviour
{

    Animator anim;
    MeshCollider myCollider;
    [SerializeField] float currentDamage = 0f;
    public bool hasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myCollider = GetComponentInChildren<MeshCollider>();
    }

    public void TurnColliderOnForSeconds(float startTime, float endTime)
    {
        float animRealTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (animRealTime >= startTime && animRealTime >= endTime)
        {
            myCollider.enabled = false;
        }
        if (animRealTime >= startTime && animRealTime < endTime)
        {
            myCollider.enabled = true;
        }

    }
    public void DealDamage(float damage)
    {

    }

    public void SetCurrentDamage(float dmg)
    {
        currentDamage = dmg;
    }
    public float GetCurrentDamage()
    {
        return currentDamage;
    }

}
