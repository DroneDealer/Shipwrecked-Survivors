using UnityEngine;

public class ShellSpawnScript : MonoBehaviour
{
    public ShellWeight[] shells;
    public float spawnRate = 2;
    private float timer = 0;
    public float widthOffset = 14;
    void Update()
    {
        if (shells == null || shells.Length == 0)
            return;

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnShell();
            timer = 0;
        }
    }
    void spawnShell()
    {
        if (shells.Length == 0) return;

        float totalWeight = 0f;
        foreach (var s in shells)
        {
            totalWeight += s.weight;
        }
        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0f;

        foreach (var s in shells)
        {
            cumulativeWeight += s.weight;
            if (randomValue <= cumulativeWeight)
            {
                float leftmostPoint = transform.position.x - widthOffset;
                float rightmostPoint = transform.position.x + widthOffset;
                Vector3 spawnPosition = new Vector3(Random.Range(leftmostPoint, rightmostPoint), transform.position.y, 0f);
                Instantiate(s.shellPrefab, spawnPosition, Quaternion.identity);
                return;
            }
        }
    }
}