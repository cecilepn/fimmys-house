using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    private int hitCount = 0;
    public int maxHits = 3;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
    }

    public void HitObstacle()
    {
        hitCount++;
        score -= 20;
        Debug.Log("Touché ! (" + hitCount + "/3) Score: " + score);

        if (hitCount >= maxHits)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("💀 Game Over !");
        // Recharge la scène pour recommencer (ou tu peux afficher un menu)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
