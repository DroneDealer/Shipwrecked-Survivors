using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public LogicScript logicScript;
    public GameObject shipCanvas;
    public Transform shipLocation;
    public AudioSource audioSource;
    public AudioClip gameOVerMusic;
    void Start()
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();
        gameOverCanvas.SetActive(false);
    }

    public void GameOverNow()
    {
        Debug.Log("Game OverNOw");
        logicScript.CheckHighScore();
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        finalScoreText.text = "Shells: " + logicScript.playerScore.ToString();
        highScoreText.text = "High Score: " + logicScript.GetHighScore().ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void GoToShipwreck()
    {
        gameOverCanvas.SetActive(false);
        shipCanvas.SetActive(true);
        Time.timeScale = 1f;
    }
}