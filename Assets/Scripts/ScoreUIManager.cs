using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public void IncrementScore()
    {
        GameManager.Instance.Score += 1;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Score: {GameManager.Instance.Score}";
    }
}
