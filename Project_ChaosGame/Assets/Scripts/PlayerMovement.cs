using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Camera mainCamera;
    public PlayerScriptObj player;

    Vector3 movementDirection;
    Rigidbody rb;

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

            Quaternion rotation = Quaternion.Slerp(rb.rotation,
                                                 Quaternion.LookRotation(CameraDirection(movementDirection)),
                                                 player.turnSpeed);

            rb.MoveRotation(rotation);

        }
    }

    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    void MoveThePlayer()
    {
        Vector3 movement = CameraDirection(movementDirection) * player.moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
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
