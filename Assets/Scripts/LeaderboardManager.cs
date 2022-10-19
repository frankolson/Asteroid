using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreboardText;
    
    void Start()
    {
        PrintLeaderboard();
    }

    void PrintLeaderboard()
    {
        if (GameManager.Instance.playerStats.Count > 0)
        {
            scoreboardText.text = "";
            IEnumerable<GameManager.PlayerStat> leaderboard = GameManager.Instance.playerStats
                .OrderByDescending(stat => stat.score)
                .Take(5);
            
            foreach (GameManager.PlayerStat playerStat in leaderboard)
            {
                scoreboardText.text += $"{playerStat.name} - {playerStat.score}\n";
            }
        }
        else
        {
            scoreboardText.text = "No gameplays yet...";
        }
    }
}
