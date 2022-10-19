using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public const string savedataFilename = "savedata.json";

    [SerializeField] bool _isGameActive = true;
    [SerializeField] int _score;
    [SerializeField] float _currentLevel;
    [SerializeField] string _playerName;

    public List<PlayerStat> playerStats = new List<PlayerStat>();
    
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
    public string PlayerName {
        get { return _playerName; }
        set { _playerName = value; }
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadLeaderboard();
    }

    public void StartGame(float level)
    {
        IsGameActive = true;
        Score = 0;
        CurrentLevel = level;
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    public class PlayerStat
    {
        public string name;
        public int score;
    }

    [System.Serializable]
    class PlayerStatsList
    {
        public List<PlayerStat> playerStats;
    }

    public void SavePlayerStat()
    {
        PlayerStat currentPlayerStat = new PlayerStat();
        currentPlayerStat.name = PlayerName;
        currentPlayerStat.score = Score;
        
        playerStats.Add(currentPlayerStat);
        SaveLeaderboard();
    }

    void SaveLeaderboard()
    {
        Debug.Log("Saving player stats...");
        PlayerStatsList data = new PlayerStatsList();
        data.playerStats = playerStats;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        File.WriteAllText($"{Application.persistentDataPath}/{savedataFilename}", json);
    }

    void LoadLeaderboard()
    {
        string path = $"{Application.persistentDataPath}/{savedataFilename}";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerStatsList data = JsonUtility.FromJson<PlayerStatsList>(json);

            if (data.playerStats != null)
            {
                playerStats = data.playerStats;
            }
        }
    }
}
