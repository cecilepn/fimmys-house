using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    private int hitCount = 0;
    public int maxHits = 2;

    public GameObject gameOverUI;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void HitObstacle()
    {
        hitCount++;
        Debug.Log("Obstacle hit! Count: " + hitCount);

        if (hitCount > maxHits)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
