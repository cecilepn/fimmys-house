using UnityEngine;

public class PlayerMovementRunner : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float laneDistance = 3f;
    public float jumpForce = 0.5f;
    public float gravity = -40f;

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

        // Mouvement de base (avant)
        Vector3 move = Vector3.forward * forwardSpeed;

        // Mouvement latéral
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
            currentLane--;
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
            currentLane++;

        Vector3 targetPos = transform.position;
        targetPos.x = (currentLane - 1) * laneDistance;
        float xDiff = targetPos.x - transform.position.x;
        move.x = xDiff * 10f; // Lerp-like sans Lerp

        // Saut
        if (controller.isGrounded)
        {
            verticalVelocity = -1f; // coller au sol
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

        // Appliquer mouvement complet
        controller.Move(move * Time.deltaTime);
    }
}
