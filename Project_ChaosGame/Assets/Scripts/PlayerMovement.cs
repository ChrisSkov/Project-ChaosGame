using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float slowFactor = 1;
    public float rotateSlowFactor = 1;
    
    public PlayerScriptObj player;
    Camera mainCamera;

    Vector3 movementDirection;
    Rigidbody rb;
    bool rotateSlow = false;
    bool canMove = true;
    bool moveSlow = false;
    bool canRotate = true;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.myPosition = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
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
            if (rotateSlow)
            {
                rotateSlowFactor = 1.15f;
            }
            else
            {
                rotateSlowFactor = 1;
            }
            Quaternion rotation = Quaternion.Slerp(rb.rotation,
                                                 Quaternion.LookRotation(CameraDirection(movementDirection)),
                                                 player.turnSpeed / rotateSlowFactor);
            if (canRotate)
            {
                rb.MoveRotation(rotation);
            }

        }
    }

    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    void MoveThePlayer()
    {
        if (moveSlow)
        {
            slowFactor = 1.65f;
        }
        else
        {
            slowFactor = 1;
        }
        Vector3 movement = CameraDirection(movementDirection) * player.moveSpeed / slowFactor * Time.deltaTime;
        if (canMove)
        {
            rb.MovePosition(transform.position + movement);
        }
    }

    public void CanMove()
    {
        canMove = true;
    }

    public void CannotMove()
    {
        canMove = false;
    }

    public void MoveSlow()
    {
        moveSlow = true;
    }

    public void MoveNotSlow()
    {
        moveSlow = false;
    }

    public void CannotRotate()
    {
        canRotate = false;
    }

    public void CanRotate()
    {
        canRotate = true;
    }
    public void RotateSlow()
    {
        rotateSlow = true;;
    }

    public void RotateNotSlow()
    {
        rotateSlow = false;;
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
