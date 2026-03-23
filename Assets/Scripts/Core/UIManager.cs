using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI statusText;

    void Update()
    {
        if (GameManager.Instance == null) return;

        scoreText.text = "Score: " + GameManager.Instance.score;
        livesText.text = "Lives: " + GameManager.Instance.lives;

        if (statusText != null)
        {
            if (GameManager.Instance.gameWon)
                statusText.text = "YOU WIN!";
            else if (GameManager.Instance.lives <= 0)
                statusText.text = "GAME OVER!";
            else
                statusText.text = "";
        }
    }
}
