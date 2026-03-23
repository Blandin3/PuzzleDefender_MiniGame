using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int lives = 3;
    public bool gameWon = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Time.timeScale = 1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
        CheckWinCondition(0);
    }

    public void EnemyDefeated()
    {
        if (lives <= 0) return;
        score += 10;
        Debug.Log("Score: " + score);
    }

    public void CheckWinCondition(int enemiesRemaining)
    {
        if (lives > 0 && score >= 200)
            WinGame();
    }

    void WinGame()
    {
        gameWon = true;
        Debug.Log("YOU WIN!");
        Time.timeScale = 0f;
    }

    public void LoseLife()
    {
        if (lives <= 0) return;

        lives--;
        Debug.Log("Lives: " + lives);

        if (lives <= 0)
            GameOver();
    }

    void GameOver()
    {
        Debug.Log("GAME OVER!");
        Time.timeScale = 0f;
    }
}
