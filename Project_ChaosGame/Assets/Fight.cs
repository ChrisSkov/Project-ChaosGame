using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fight : MonoBehaviour
{
    public int id;
    PlayerAnimation playerAnim;
    public PlayerScriptObj player;

    [Header("Transforms")]
    public Transform shovelTip;
    public Transform throwAim;
    public Transform slamEffectPos;

    [Header("Damage values")]
    public float atk_1DMG = 8f;
    public float atk_2DMG = 12f;
    public float atk_3DMG = 20f;
    public float throwDMG = 20f;
    public float shovelRadius = 0.7f;


    [Header("Cooldown and timers")]
    public int atkCount = 0;
    public int atkCountMax = 2;
    public float timeBeforeAtkReset = 3f;
    public float atkResetTimer = 0;


    [Header("Effects")]
    public GameObject[] atkEffects;

    [Header("Audio")]
    public AudioClip[] swingSounds;
    public AudioClip[] hitSounds;
    public AudioClip[] slamSounds;
    public AudioClip[] slamJumpSounds;

    bool canCancel = true;
    public bool blockAttacks = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();

    }

    // Update is called once per frame
    void Update()
    {
     

        if (atkCount > 0)
        {
            atkResetTimer += Time.deltaTime;
            if (atkResetTimer >= timeBeforeAtkReset || atkCount >= atkCountMax)
            {
                atkCount = 0;
                atkResetTimer = 0;
            }
        }
    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.performed )
        {
    
            playerAnim.PlayAttackAnimation(atkCount);

        }
    }
    public void AttackAnimEven()
    {

        LayerMask mask = LayerMask.GetMask("Hitable");
        foreach (Collider c in Physics.OverlapSphere(shovelTip.position, shovelRadius, mask))
        {
            if (c.gameObject.tag == "Player")
            {
                if (atkCount == 0)
                {
                    c.GetComponent<Health>().TakeDamage(atk_1DMG, id);
                    if (c.GetComponent<Fight>().id != id)
                    {
                        GameObject clone = Instantiate(atkEffects[atkCount], shovelTip.position, transform.rotation);
                        Destroy(clone, 2f);
                    }
                }
                else if (atkCount == 1)
                {
                    c.GetComponent<Health>().TakeDamage(atk_2DMG, id);
                    if (c.GetComponent<Fight>().id != id)
                    {
                        GameObject clone = Instantiate(atkEffects[atkCount], shovelTip.position, transform.rotation);
                        Destroy(clone, 2f);
                        GetComponent<AudioSource>().PlayOneShot(slamSounds[Random.Range(0, slamSounds.Length)]);
                    }
                }
            }
        }
        atkCount++;
        if (atkCount > atkCountMax)
        {
            atkCount = 0;
        }
    }

    public void SlamJumpSound()
    {
        GetComponent<AudioSource>().PlayOneShot(slamJumpSounds[Random.Range(0, slamJumpSounds.Length)]);
    }
    public void OnExitAttack(InputAction.CallbackContext value)
    {
        if (value.performed && canCancel)
        {
            playerAnim.ExitAnim();
        }
    }

    public void ThrowAnimEvent()
    {
        LayerMask mask = LayerMask.GetMask("Hitable");
        foreach (Collider c in Physics.OverlapSphere(throwAim.position, shovelRadius, mask))
        {
            if (c.gameObject.tag == "Player")
            {
                if (c.GetComponent<Health>().myID != id)
                {
                    c.transform.LookAt(transform.position);
                    transform.LookAt(c.transform.position);
                    if (!c.GetComponent<Health>().dead)
                    {
                        c.GetComponent<PlayerAnimation>().PlayIsThrownAnim();
                    }
                }
            }
        }
    }

    public void ThrowAnimDMGEvent()
    {
        GetComponent<Health>().TakeDamage(throwDMG, 4);
    }

    public void CanCancel()
    {
        canCancel = true;
    }

    public void CannotCancel()
    {
        canCancel = false;
    }
    public void AttackSoundEvent()
    {
        GetComponent<AudioSource>().PlayOneShot(swingSounds[Random.Range(0, swingSounds.Length)]);
    }

    public void BlockAttackStart()
    {
        blockAttacks = true;
    }

    public void BlockAttacksEnd()
    {
        blockAttacks = false;
    }
}
