using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirkFu : MonoBehaviour
{

    Animator anim;
    MeshCollider myCollider;
    public bool hasHit = false;
    AudioSource source;
    BrawlAttackScriptObj currentAtkObj;
    public BrawlScriptObj player;
    public float impactVolume = 0.08f;
    public float defaultVolume = 0.5f; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        myCollider = GetComponentInChildren<MeshCollider>();
    }

    public void TurnColliderOnForSeconds(float startTime, float endTime)
    {
        float animRealTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (animRealTime >= startTime && animRealTime >= endTime)
        {
            myCollider.enabled = false;
            hasHit = false;
        }
        if (animRealTime >= startTime && animRealTime < endTime)
        {
            myCollider.enabled = true;
        }
        
    }

    public void PlayImpactSound()
    {
        source.volume = impactVolume;
        source.PlayOneShot(player.impactSounds[0]);
    }
    public void DealDamage(float damage)
    {

    }

    public void SetCurrentDamage(BrawlAttackScriptObj atkObj)
    {
        currentAtkObj = atkObj;
    }
    public BrawlAttackScriptObj GetCurrentAttack()
    {
        return currentAtkObj;
    }

}
