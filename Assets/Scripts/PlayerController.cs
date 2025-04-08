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
    private float xRotation = 0f;

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
        HandleLook();
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 move = transform.right * inputMovement.x + transform.forward * inputMovement.y;
        controller.Move(move.normalized * speed * Time.deltaTime);

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

    void HandleLook()
    {
        float mouseX = lookDelta.x * mouseSensitivity;
        float mouseY = lookDelta.y * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // haut/bas
        transform.Rotate(Vector3.up * mouseX); // gauche/droite
    }
}
