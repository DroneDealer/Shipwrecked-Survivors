using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    public int playerID = 1;
    private bool IsDead = false;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (IsDead)
        {
            return;
        }
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (playerID == 1)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        else if (playerID == 2)
        {
            horizontalInput = Input.GetAxis("Horizontal2");
            verticalInput = Input.GetAxis("Vertical2");
        }
        else if (playerID == 3)
        {
            horizontalInput = Input.GetAxis("Horizontal3");
            verticalInput = Input.GetAxis("Vertical3");
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        if (horizontalInput != 0)
        {
            spriteRenderer.flipX = horizontalInput < 0;
        }
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f);
        transform.position += direction * speed * Time.deltaTime;
    }
    public void Die()
    {
        Debug.Log("Die() called");
        if (IsDead) return;

        IsDead = true;
        animator.SetBool("IsDead", true);
        Debug.Log("Die called. IsDead param set to true");

        //animator.Play("DeathAnimation", 0, 0f);
        Debug.Log("Forced animation play");
        FindObjectOfType<GameOver>().GameOverNow();

        //speed = 0f;
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;
        }
        StartCoroutine(DelayedGameOver());
    }
    private IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(1f);

        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.CompareTag("GameController") || obj.CompareTag("GameOverUI") || obj.CompareTag("MainCamera") || obj.name == "EventSystem" || obj.CompareTag("ShipUI") || obj.CompareTag("Managers") || obj.CompareTag("Logic"))
            {
                continue;
            }
            obj.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}