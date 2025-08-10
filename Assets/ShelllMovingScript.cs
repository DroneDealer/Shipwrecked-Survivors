using UnityEngine;

public class ShelllMovingScript : MonoBehaviour
{
    public LogicScript Logic;
    public float moveSpeed = 3;
    public float deadZone = -3;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;

        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
            Logic.LoseLife();
        }
    }
}