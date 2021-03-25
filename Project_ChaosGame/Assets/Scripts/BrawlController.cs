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
    // Start is called before the first frame update
    void Start()
    {
        brawlHealth = GetComponent<BrawlHealth>();
        brawlAnim = GetComponent<BrawlAnim>();
        playerMove = GetComponent<BrawlMove>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();
        UpdatePlayerAnimationMovement();
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
}
