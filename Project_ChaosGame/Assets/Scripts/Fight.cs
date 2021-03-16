using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Fight : MonoBehaviour
{
    public int id;
    PlayerAnimation playerAnim;
    public PlayerScriptObj player;
    public Collider hitBox;

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
    public float atkCD = 0.5f;
    public float atkTimer = Mathf.Infinity;

    [Header("Effects")]
    public GameObject[] atkEffects;
    public GameObject[] blockEffects;

    [Header("Audio")]
    public AudioClip[] swingSounds;
    public AudioClip[] hitSounds;
    public AudioClip[] slamSounds;
    public AudioClip[] slamJumpSounds;

    [Header("Weapons")]
    public GameObject[] playerWeps;
    public GameObject[] shields;

    [Header("UI")]
    public TMP_Text text;
    bool canCancel = true;
    public bool blockAttacks = false;
    bool canAttack = true;

    public bool canThrow = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();
        playerWeps[id].gameObject.SetActive(true);
        shields[id].gameObject.SetActive(true);
        text.SetText("P" + (id + 1));
    }

    // Update is called once per frame
    void Update()
    {
        ThrowAnimEvent();

        atkTimer += Time.deltaTime;
        if (atkTimer >= atkCD)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
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
        if (value.performed)
        {
            playerAnim.PlayAttackAnimation(atkCount, canAttack);
        }
    }

    public void DetectHit(Collider c)
    {

        if (atkCount == 0)
        {
            c.GetComponent<Health>().TakeDamage(atk_1DMG, id, gameObject);
            if (c.GetComponent<Fight>().id != id)
            {
                SpawnAtkEffect();
            }
        }
        else if (atkCount == 1)
        {
            c.GetComponent<Health>().TakeDamage(atk_2DMG, id, gameObject);
            if (c.GetComponent<Fight>().id != id)
            {
                SpawnAtkEffect();

            }
        }
        atkCount++;
        if (atkCount > atkCountMax)
        {
            atkCount = 0;
        }

    }

    public void SpawnBlockEffect()
    {

        GameObject clone = Instantiate(blockEffects[Random.Range(0, blockEffects.Length)], shields[id].gameObject.transform.position, shields[id].gameObject.transform.rotation);
        Destroy(clone, 2f);
    }

    private void SpawnAtkEffect()
    {
        GameObject clone = Instantiate(atkEffects[atkCount], shovelTip.position, transform.rotation);
        Destroy(clone, 2f);
    }

    public void SlamJumpSound()
    {
        GetComponent<AudioSource>().PlayOneShot(slamJumpSounds[Random.Range(0, slamJumpSounds.Length)]);
    }


    public void StartThrowEvent()
    {
        canThrow = true;
    }

    public void StopThrowEvent()
    {
        canThrow = false;
    }
    public void ThrowAnimEvent()
    {
        LayerMask mask = LayerMask.GetMask("Hitable");
        if (canThrow)
        {
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
                            canThrow = false;
                        }
                    }
                }
            }
        }
    }

    public void EnableHitBox()
    {
        hitBox.enabled = true;
    }

    public void DisableHitBox()
    {
        hitBox.enabled = false;
    }
    public void ThrowAnimDMGEvent()
    {
        GetComponent<Health>().TakeDamage(throwDMG, 4, gameObject);
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
