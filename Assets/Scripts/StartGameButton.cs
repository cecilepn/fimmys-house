using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LandingGame");
    }
    public void SeeCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
