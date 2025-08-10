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
        if (audioSource != null && grabShell != null)
        {
            audioSource.PlayOneShot(grabShell);
        }
        else
        {
            Debug.Log("Either your audio manager or your audio clip are unassigned!");
        }
        Logic.addScore(shellWorth);
        Destroy(gameObject);
    }
}