using UnityEngine;

public class PlayerMovementRunner : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float laneDistance = 3f;
    public float jumpForce = 0.5f;
    public float gravity = -40f;
    public float speedIncreaseRate = 0.1f; // Speed gain per second
    public float maxSpeed = 10f; // Cap to prevent it from going too fast

    private int currentLane = 1;
    private float verticalVelocity = 0f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller == null) return;

        // Increase forward speed over time
        forwardSpeed += speedIncreaseRate * Time.deltaTime;
        forwardSpeed = Mathf.Clamp(forwardSpeed, 0, maxSpeed);

        // Base forward movement
        Vector3 move = Vector3.forward * forwardSpeed;

        // Lateral lane switching
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
            currentLane--;
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
            currentLane++;

        Vector3 targetPos = transform.position;
        targetPos.x = (currentLane - 1) * laneDistance;
        float xDiff = targetPos.x - transform.position.x;
        move.x = xDiff * 10f; // Quick interpolation without Lerp

        // Jumping
        if (controller.isGrounded)
        {
            verticalVelocity = -1f; // Stick to ground
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        move.y = verticalVelocity;

        controller.Move(move * Time.deltaTime);
    }
}
