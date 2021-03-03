using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fight : MonoBehaviour
{
    public PlayerScriptObj player;
    PlayerAnimation playerAnim;
    public Transform shovelTip;
    public float shovelRadius = 0.7f;
    public float damage = 12f;
    public int id;

    bool canCancel = true;
    public AudioClip[] hitSounds;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            playerAnim.PlayAttackAnimation();
        }
    }
    public void AttackAnimEven()
    {
        LayerMask mask = LayerMask.GetMask("Hitable");
        foreach (Collider c in Physics.OverlapSphere(shovelTip.position, shovelRadius, mask))
        {
            if (c.gameObject.tag == "Player")
            {
                c.GetComponent<Health>().TakeDamage(damage, id);
            }
        }
    }

    public void OnExitAttack(InputAction.CallbackContext value)
    {
        if (value.performed && canCancel)
        {
            playerAnim.ExitAnim();
        }
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
        GetComponent<AudioSource>().PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
    }
}
