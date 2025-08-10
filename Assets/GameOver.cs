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
    public GameObject player;
    public GameObject player1;
    public GameObject player2;
    public AudioSource audioSource;
    public AudioClip gameOVerMusic;
    void Start()
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();
        gameOverCanvas.SetActive(false);
    }

    public void GameOverNow()
    {
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
    public void GoToWorldTree()
    {
        gameOverCanvas.SetActive(false);
        shipCanvas.SetActive(true);
        Time.timeScale = 1f;
        player.SetActive(false);
        player1.SetActive(true);
        player.transform.position = shipLocation.position;
    }
}