using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    public void StartGame(float level)
    {
        string playerName = GameManager.Instance.PlayerName;
        if (playerName != null && playerName != "")
        {
            GameManager.Instance.StartGame(level);
        }
    }

    public void UpdatePlayerName(string newName)
    {
        GameManager.Instance.PlayerName = newName;
    }
}
