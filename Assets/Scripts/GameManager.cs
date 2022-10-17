using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] bool _isGameActive = true;
    [SerializeField] int _score;
    [SerializeField] float _currentLevel;
    
    public bool IsGameActive {
        get { return _isGameActive; }
        set { _isGameActive = value; }
    }
    public int Score {
        get { return _score; }
        set { _score = value; }
    }
    public float CurrentLevel {
        get { return _currentLevel; }
        private set { _currentLevel = value; }
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame(float level)
    {
        IsGameActive = true;
        Score = 0;
        CurrentLevel = level;
        SceneManager.LoadScene(1);
    }
}
