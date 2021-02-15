using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Animator playerAnim;
    public float movementSpeed = 5f;
    public float turnSpeed = 5f;
    Playermap controls;
    public Vector2 move;
    Vector2 rotate;
    Vector3 movementDirection;
    Rigidbody rb;
    private void Awake()
    {
        controls = new Playermap();

        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;
        controls.Player.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Player.Rotate.canceled += ctx => rotate = Vector2.zero;
    }
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveThePlayer();
        TurnThePlayer();
    }

    void TurnThePlayer()
    {
        movementDirection = new Vector3(move.x, 0, move.y);
        if (movementDirection.sqrMagnitude > 0.01f)
        {

            Quaternion rotation = Quaternion.Slerp(rb.rotation,
                                                 Quaternion.LookRotation(CameraDirection(movementDirection)),
                                                 turnSpeed);

            rb.MoveRotation(rotation);

        }
    }


    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    void MoveThePlayer()
    {
        movementDirection = new Vector3(move.x, 0, move.y);
    
    
        playerAnim.SetFloat("forwardSpeed", movementDirection.magnitude);
        // playerAnim.SetFloat("horizontalSpeed", MertInput.horizontal);
        // playerAnim.SetFloat("forwardSpeed", MertInput.vertical);

        //Equalize strictly veritcal/horizontal speed with diagonal speed
        if (movementDirection.magnitude >= .05)
        {
            movementDirection = movementDirection.normalized;
            playerAnim.SetBool("isRunning", true);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }
        Vector3 movement = CameraDirection(movementDirection) * movementSpeed * Time.deltaTime;
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
