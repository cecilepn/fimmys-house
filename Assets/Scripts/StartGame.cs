using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject interactionUI;
    private bool isPlayerNear = false;

    void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("BeforeStartingRunner");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }
}
