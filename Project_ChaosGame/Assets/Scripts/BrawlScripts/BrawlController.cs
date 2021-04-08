using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(BrawlHealth), typeof(BrawlMove), typeof(BrawlAnim))]
public class BrawlController : MonoBehaviour
{
    BrawlHealth brawlHealth;
    BrawlMove brawlMove;
    BrawlAnim brawlAnim;
    KirkFu brawlFight = null;

    private Vector3 smoothInputMovement;
    private Vector3 rawInputMovement;
    public BrawlScriptObj player;
    PlayerInput playerInput;
    //Action Maps
    private string actionMapPlayerControls = "Player";
    private string actionMapMenuControls = "Menu";

    HandleCharacterChange characterChange;
    // Start is called before the first frame update
    void Awake()
    {
        characterChange = GetComponent<HandleCharacterChange>();
        SetUpScripts();
        playerInput.SwitchCurrentActionMap(playerInput.defaultActionMap);
        ChangeClass(player);
    }

    private void SetUpScripts()
    {
        brawlFight = GetComponent<KirkFu>();
        playerInput = GetComponent<PlayerInput>();
        brawlHealth = GetComponent<BrawlHealth>();
        brawlAnim = GetComponent<BrawlAnim>();
        brawlMove = GetComponent<BrawlMove>();
    }

    public void ChangeClass(BrawlScriptObj myPlayer)
    {
        brawlFight.SetPlayer(myPlayer);
        brawlHealth.SetPlayer(myPlayer);
        brawlMove.SetPlayer(myPlayer);
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

    public void OnChooseChar(InputAction.CallbackContext ctx)
    {
        characterChange.ChangeToWizard();
    }
    public void OnChooseChar1(InputAction.CallbackContext ctx)
    {
        characterChange.ChangeToWarrior();
    }

    public void OnLightAttack(InputAction.CallbackContext ctx)
    {
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

        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * player.moveSmoothing);
    }

    void UpdatePlayerMovement()
    {
        brawlMove.UpdateMovementData(smoothInputMovement);
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

    public BrawlScriptObj GetCharacter()
    {
        return player;
    }
}
