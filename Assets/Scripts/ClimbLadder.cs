using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    public float climbSpeed = 3f;
    private bool isPlayerNear = false;
    private bool isClimbing = false;
    private CharacterController playerController;
    private GameObject player;
    public GameObject interactionUI;

    void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)))
        {
            isClimbing = true;
        }

        if (isClimbing && (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space)))
        {
            Vector3 climbDirection = Vector3.up * climbSpeed * Time.deltaTime;
            playerController.Move(climbDirection);
        }

        // Optionnel : arrêter de grimper quand aucune touche n’est pressée
        if (!Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Space))
        {
            isClimbing = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            player = other.gameObject;
            playerController = player.GetComponent<CharacterController>();

            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            isClimbing = false;

            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }
}
