using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScoreText1;
    public TextMeshProUGUI finalScoreText2;
    public TextMeshProUGUI finalScoreText3;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    public void GameOverNow()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;

        PlayerScore[] players = FindObjectsOfType<PlayerScore>();
        int maxScore = 0;

        if (players.Length >= 3)
        {
            finalScoreText1.text = "Player 1 Shells: " + players[0].GetScore();
            finalScoreText2.text = "Player 2 Shells: " + players[1].GetScore();
            finalScoreText3.text = "Player 3 Shells: " + players[2].GetScore();

            foreach (var player in players)
            {
                if (player.GetScore() > maxScore)
                    maxScore = player.GetScore();
            }
        }
        else
        {
            finalScoreText1.text = "Player 1 Shells: 0";
            finalScoreText2.text = "Player 2 Shells: 0";
            finalScoreText3.text = "Player 3 Shells: 0";
        }

        highScoreText.text = "High Score: " + maxScore;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}