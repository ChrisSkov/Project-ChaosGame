using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{

    public PlayerScriptObj player;
    PlayerAnimation playerAnim;
    public Transform shovelTip;
    public Transform barrelAim;
    public Transform rayAim;
    Vector3 barrelPos;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
      
    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            playerAnim.PlayAttackAnimation();
        }
    }

    public void OnPlaceBarrel(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (player.currentBarrels >= 1)
            {
                GameObject barrelClone = Instantiate(player.barrelPrefab, new Vector3(barrelAim.position.x, 0, barrelAim.position.z), transform.rotation);
                player.currentBarrels--;
            }


        }
    }

    public void OnPickUpBarrel(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            LayerMask mask = LayerMask.GetMask("Hitable");
            RaycastHit hit;
            if (Physics.Raycast(rayAim.position, transform.forward, out hit, 1.3f, mask))
            {

                if (hit.collider.gameObject.tag == "Barrel" && player.currentBarrels < player.maxBarrels)
                {
                    player.currentBarrels++;
                    Destroy(hit.collider.GetComponentInParent<SphereCollider>().gameObject);
                }
            }
        }
    }

    void AttackAnimEvent()
    {
        LayerMask mask = LayerMask.GetMask("Hitable");
        foreach (Collider c in Physics.OverlapSphere(shovelTip.position, 1f, mask))
        {
            if (c.gameObject.tag == "Barrel")
            {
                c.GetComponentInParent<BarrelHealth>().isTriggered = true;
            }
        }
    }

}
