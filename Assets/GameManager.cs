using UnityEngine;
using TMPro; // Namespace for TextMeshPro
using UnityEngine.SceneManagement; // Namespace for reloading scenes

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton for easy access

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // Pauses the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Unpause
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}