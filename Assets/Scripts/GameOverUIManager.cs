using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;

    public void TriggerGameOver()
    {
        if (GameManager.Instance.IsGameActive)
        {
            GameManager.Instance.IsGameActive = false;
            GameManager.Instance.SavePlayerStat();
            gameOverScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
