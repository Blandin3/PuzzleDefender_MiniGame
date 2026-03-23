using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI instructionsText;
    public Button startButton;
    public TextMeshProUGUI startButtonText;

    void Start()
    {
        titleText.text = "PUZZLE DEFENDER";

        instructionsText.text =
            "HOW TO PLAY\n\n" +
            "OBJECTIVE\n" +
            "Stop enemies from reaching the green goal.\n" +
            "You have 3 lives. Reach 200 points to WIN!\n\n" +
            "CONTROLS\n" +
            "Arrow Keys / WASD  —  Move the player\n" +
            "Mouse Click on Enemy  —  Destroy it (+10 score)\n\n" +
            "ENEMIES\n" +
            "Yellow (Fast)  —  Moves quickly toward the goal\n" +
            "Purple (Tank)  —  Moves slowly but is bigger\n" +
            "Hover over an enemy to highlight it, then click!\n\n" +
            "WIN CONDITION\n" +
            "Earn 200 points before losing all 3 lives\n\n" +
            "LOSE CONDITION\n" +
            "Let 3 enemies reach the green goal\n" +
            "Lives: 3 -> 2 -> 1 -> 0 = GAME OVER";

        startButtonText.text = "START GAME";
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
