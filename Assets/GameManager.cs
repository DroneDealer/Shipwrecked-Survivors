using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject player = Instantiate(playerPrefab, spawnPoints[i].position, Quaternion.identity);

            PlayerScore ps = player.GetComponent<PlayerScore>();
            if (ps != null)
            {
                ps.ScoreText = GameObject.Find("Score_Player" + (i + 1))?.GetComponent<TextMeshProUGUI>();
                if (ps.ScoreText == null)
                    Debug.LogWarning("Score_Player" + (i + 1) + " UI text not found!");
            }
            PlayerLabel label = player.GetComponentInChildren<PlayerLabel>();
            if (label != null)
            {
                label.playerID = i + 1;
            }
        }
    }
}