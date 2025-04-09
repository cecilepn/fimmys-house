using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Mouvement")]
    public float speed = 6.0f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    [Header("Souris")]
    public float mouseSensitivity = 2f;
    public Transform cameraRoot;

    private Vector2 inputMovement;
    private Vector2 lookDelta;
    private Vector3 velocity;
    private CharacterController controller;

    private PlayerInputActions inputActions;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += ctx => inputMovement = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => inputMovement = Vector2.zero;

        inputActions.Player.Look.performed += ctx => lookDelta = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => lookDelta = Vector2.zero;

        inputActions.Player.Jump.performed += ctx => Jump();
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Direction de mouvement locale (caméra)
        Vector3 moveDirection = new Vector3(inputMovement.x, 0, inputMovement.y);
        moveDirection = Quaternion.Euler(0, cameraRoot.eulerAngles.y, 0) * moveDirection;
        moveDirection.Normalize();

        // Rotation douce du joueur vers la direction du mouvement
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Appliquer le mouvement horizontal
        Vector3 horizontalMove = moveDirection * speed * Time.deltaTime;
        controller.Move(horizontalMove);

        // Gravité
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    void Jump()
    {
        if (controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
