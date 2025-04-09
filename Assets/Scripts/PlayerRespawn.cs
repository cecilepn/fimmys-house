using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startPosition;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
    }

    public void Respawn()
    {
        // Reset velocity 
        controller.enabled = false;
        transform.position = startPosition;
        controller.enabled = true;
    }
}
