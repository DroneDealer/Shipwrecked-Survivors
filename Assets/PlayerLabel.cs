using TMPro;
using UnityEngine;
public class PlayerLabel : MonoBehaviour
{
    public TextMeshProUGUI labelText;
    public int playerID;
    void Start()
    {
        if(labelText != null)
        {
            labelText.text = "Player " + playerID;
        }
    }
}