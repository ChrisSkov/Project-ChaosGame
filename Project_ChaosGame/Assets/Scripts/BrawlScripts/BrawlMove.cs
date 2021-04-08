using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlMove : MonoBehaviour
{
    BrawlScriptObj player;
    public bool canMove = true;
    public float currentSpeed;
    Camera mainCamera;
    Vector3 movementDirection;
    Rigidbody rb;
    public float fadeInMultiplier = 20f;
    public float fadeOutMultiplier = 20f;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = player.moveSpeed;
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

    }
    public void SetPlayer(BrawlScriptObj newPlayer)
    {
        player = newPlayer;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;
        if (currentSpeed >= player.moveSpeed)
        {
            currentSpeed = player.moveSpeed;
        }
        MoveThePlayer();
        TurnThePlayer();
    }
    public void SetupBehaviour()
    {
        SetGameplayCamera();
    }

    void SetGameplayCamera()
    {
        mainCamera = Camera.main;
    }
    void TurnThePlayer()
    {
        if (movementDirection.sqrMagnitude > 0.01f)
        {
            Quaternion rotation = Quaternion.Slerp(rb.rotation,
                                                 Quaternion.LookRotation(CameraDirection(movementDirection)),
                                                 player.rotationSpeed);

            rb.MoveRotation(rotation);
        }
    }
    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }
    void MoveThePlayer()
    {

        Vector3 movement = CameraDirection(movementDirection) * currentSpeed * Time.deltaTime;
        if (canMove)
        {
            rb.MovePosition(transform.position + movement);
        }
    }

    public void FadeMoveSpeedIn()
    {
        if (currentSpeed <= player.moveSpeed)
        {
            currentSpeed += fadeInMultiplier;
        }
    }
    public void FadeMoveSpeedOut()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= fadeOutMultiplier;
        }
    }

    Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        return cameraForward * movementDirection.z + cameraRight * movementDirection.x;

    }
}
