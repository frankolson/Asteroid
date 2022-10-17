using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreboardText;
    
    private void Start()
    {
        scoreboardText.text = $"Will - 100\nSmalls - 98\n";
    }
}
