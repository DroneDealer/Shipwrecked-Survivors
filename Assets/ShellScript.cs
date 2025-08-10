using UnityEngine;

public class ShellScript : MonoBehaviour
{
    public int shellWorth = 5;
    public LogicScript Logic;
    public AudioSource audioSource;
    public AudioClip grabShell;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioSource = GameObject.FindObjectOfType<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered by: {collision.name}");
        if (audioSource != null && grabShell != null)
        {
            Debug.Log("Played grab shell sound.");
            audioSource.PlayOneShot(grabShell);
        }
        else
        {
            Debug.Log("Either your audio manager or your audio clip are unassigned!");
        }
        Debug.Log("Before adding score.");
        Logic.addScore(shellWorth);
        Debug.Log("After adding score.");

        Debug.Log("Before destroy.");
        Destroy(gameObject);
        Debug.Log("After destroy.");
    }
}