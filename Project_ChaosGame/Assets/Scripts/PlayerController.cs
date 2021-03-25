using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts references")]

    public PlayerAnimation playerAnim;
    public PlayerMovement playerMove;
    public Health health;
    [Header("Adjustable values")]

    public float movementSmoothingSpeed = 1f;
    public float dodgeCD = 3f;
    public float jumpCD = 3f;
    public float blockCD = 3f;
    private Vector3 smoothInputMovement;
    private Vector3 rawInputMovement;
    float dodgeTimer = Mathf.Infinity;
    float blockTimer = Mathf.Infinity;
    // float jumpTimer = Mathf.Infinity;
    // public FindPlayerTarget findPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //  findPlayer.UpdateTargetGroup();
        playerMove.SetupBehaviour();
        playerAnim.SetupBehaviour();
        health = GetComponent<Health>();
    }

    void Update()
    {
        dodgeTimer += Time.deltaTime;
        blockTimer += Time.deltaTime;
        if (health.dead)
        {
            return;
        }
        else
        {
            CalculateMovementInputSmoothing();
            UpdatePlayerMovement();
            UpdatePlayerAnimationMovement();
        }
    }

    //Input's Axes values are raw
    void CalculateMovementInputSmoothing()
    {

        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);

    }

    void UpdatePlayerMovement()
    {
        playerMove.UpdateMovementData(smoothInputMovement);
    }

    void UpdatePlayerAnimationMovement()
    {
        playerAnim.UpdateMovementAnimation(smoothInputMovement.magnitude);
    }
    //This is called from PlayerInput; when a joystick or arrow keys has been pushed.
    //It stores the input Vector as a Vector3 to then be used by the smoothing function.


    public void OnCharge(InputAction.CallbackContext ctx)
    {
        if (ctx.started || ctx.performed)
        {
            GetComponent<Fight>().chargeUp = true;
        }
        if (ctx.canceled)
        {
            playerAnim.PlayChargeAnim();
            GetComponent<Fight>().chargeUp = false;

        }
    }
    public void OnThrow(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            playerAnim.PlayThrowAnim();
        }
    }
    public void OnMovement(InputAction.CallbackContext value)
    {

        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void OnDodge(InputAction.CallbackContext ctx)
    {

        if (ctx.performed && dodgeTimer >= dodgeCD)
        {
            playerAnim.PlayDodgeAnimation();
            dodgeTimer = 0;
        }
        if (GetComponent<Health>().dead || GetComponent<Health>().winner)
        {
            SceneManager.LoadScene(0);

        }
    }

    public void OnBlockBegin(InputAction.CallbackContext ctx)
    {
        if (blockTimer >= blockCD)
        {
            blockTimer = 0;
            playerAnim.PlayBlockStartAnim();
        }
    }

    public void OnFlex(InputAction.CallbackContext ctx)
    {
        playerAnim.PlayFlexAnim();
    }

    // public void OnJump(InputAction.CallbackContext ctx)
    // {
    //     if (ctx.performed && jumpTimer >= jumpCD)
    //     {
    //         playerAnim.PlayJumpAnimation();
    //         jumpTimer = 0;
    //     }
    // }

}
