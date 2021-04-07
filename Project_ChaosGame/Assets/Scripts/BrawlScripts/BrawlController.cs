using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BrawlController : MonoBehaviour
{
    BrawlHealth brawlHealth;
    BrawlMove playerMove;
    BrawlAnim brawlAnim;
    private Vector3 smoothInputMovement;
    private Vector3 rawInputMovement;
    public BrawlScriptObj brawlerTattie;
    PlayerInput playerInput;
    //Action Maps
    private string actionMapPlayerControls = "Player";
    private string actionMapMenuControls = "Menu";
    // Start is called before the first frame update
    void Start()
    {

        playerInput = GetComponent<PlayerInput>();
        brawlHealth = GetComponent<BrawlHealth>();
        brawlAnim = GetComponent<BrawlAnim>();
        playerMove = GetComponent<BrawlMove>();
        playerInput.SwitchCurrentActionMap(playerInput.defaultActionMap);

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();
        UpdatePlayerAnimationMovement();
        if (brawlHealth.isDead)
        {
            EnablePauseMenuControls();
        }
    }


    public void OnLightAttack(InputAction.CallbackContext ctx)
    {
        print("satan");
        if (ctx.performed)
        {
            brawlAnim.PlayLightAttackAnim();
        }
    }
    public void OnDodge(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            brawlAnim.PlayDodgeAnim();
        }
    }
    public void OnHeavyAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            brawlAnim.PlayHeavyAttackAnim();
        }

    }
    //Input's Axes values are raw
    void CalculateMovementInputSmoothing()
    {

        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * brawlerTattie.moveSmoothing);
    }

    void UpdatePlayerMovement()
    {
        playerMove.UpdateMovementData(smoothInputMovement);
    }

    void UpdatePlayerAnimationMovement()
    {
        brawlAnim.UpdateMovementAnimation(smoothInputMovement.magnitude);
    }

    public void OnMovement(InputAction.CallbackContext value)
    {

        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }


    //Switching Action Maps ----
    public void EnableGameplayControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapPlayerControls);
    }

    public void EnablePauseMenuControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapMenuControls);
    }
}
