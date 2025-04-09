using UnityEngine;

public class QuitOnEscape : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitter le jeu");
    }
}
