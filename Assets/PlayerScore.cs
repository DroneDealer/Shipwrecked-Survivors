using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int playerID = 1;
    public TextMeshProUGUI ScoreText;
    private int score = 0;
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    void UpdateScoreUI()
    {
        if (ScoreText != null)
            ScoreText.text = "Player " + playerID + " Shells: " + score.ToString();
    }
}