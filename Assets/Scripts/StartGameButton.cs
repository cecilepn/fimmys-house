using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string sceneToLoad = "LandingGame";

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
