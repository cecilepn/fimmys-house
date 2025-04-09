using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;

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

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restart pressed");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SplashScreen");
    }
}
