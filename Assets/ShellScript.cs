using UnityEngine;

public class ShellScript : MonoBehaviour
{
    public int shellWorth = 5;
    public AudioSource audioSource;
    public AudioClip grabShell;

    void Start()
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered by: {collision.name}");

        if (collision.CompareTag("Player"))
        {
            PlayerScore playerScore = collision.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddScore(shellWorth);
            }

            if (audioSource != null && grabShell != null)
            {
                Debug.Log("Played grab shell sound.");
                audioSource.PlayOneShot(grabShell);
            }
            else
            {
                Debug.Log("Either your audio manager or your audio clip are unassigned!");
            }

            Debug.Log("Before destroy.");
            Destroy(gameObject);
            Debug.Log("After destroy.");
        }
    }
}