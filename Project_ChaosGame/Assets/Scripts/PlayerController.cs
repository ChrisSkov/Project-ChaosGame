using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;
    public PlayerAnimation playerAnim;
    public PlayerMovement playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove.SetupBehaviour();
        playerAnim.SetupBehaviour();
    }

    void Update()
    {
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();
        UpdatePlayerAnimationMovement();
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


    public void OnMovement(InputAction.CallbackContext value)
    {

        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void OnDodge(InputAction.CallbackContext ctx)
    {
  
        if (ctx.performed)
        {
            playerAnim.PlayDodgeAnimation();
        }
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            playerAnim.PlayJumpAnimation();
        }
    }

}
