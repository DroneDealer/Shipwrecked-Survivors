using UnityEngine;
using TMPro;

public class LogicScript : MonoBehaviour
{
    [Header("Player Info")]
    public int playerID = 1;
    [Header("Shells")]
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    [Header("Lives")]
    public int currentLives = 3;
    public TextMeshProUGUI livesText;
    public AudioSource audioSource;
    public AudioClip loseALifeSoundEffect;
    public AudioClip gameOver;
    void Start()
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();

        UpdateScoreUI();
        UpdateLivesUI();
        UpdateHighScoreUI();
    }
    public void addScore(int value)
    {
        playerScore += value;
        UpdateScoreUI();
    }
    public void LoseLife()
    {
        if (audioSource != null && loseALifeSoundEffect != null)
            audioSource.PlayOneShot(loseALifeSoundEffect);
        else
            Debug.Log("Either your Audio Source or your Audio Clip are unassigned!");

        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            if (audioSource != null && gameOver != null)
                audioSource.PlayOneShot(gameOver);
            else
                Debug.Log("Either your Audio Manager or your Audio Clip are unassigned!");

            CheckHighScore();
            Debug.Log("Game Over!");

            var playerMovement = GameObject.FindWithTag("Player")?.GetComponent<PlayerMovement>();
            if (playerMovement != null)
                playerMovement.Die();
        }
    }
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Player " + playerID + " Shells: " + playerScore.ToString();
    }
    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + currentLives.ToString();
    }
    void UpdateHighScoreUI()
    {
        int savedHighScore = PlayerPrefs.GetInt("highScore", 0);
        if (highScoreText != null)
            highScoreText.text = "High Score: " + savedHighScore.ToString();
    }
    public void CheckHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("highScore", 0);
        if (playerScore > savedHighScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            PlayerPrefs.Save();
            Debug.Log("New High Score: " + playerScore);

            if (highScoreText != null)
                highScoreText.text = "High Score: " + playerScore.ToString();
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore", 0);
    }

    [ContextMenu("Reset High Score")]
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("highScore");
        PlayerPrefs.Save();
        Debug.Log("High score reset.");
        if (highScoreText != null)
            highScoreText.text = "High Score: 0";
    }
}