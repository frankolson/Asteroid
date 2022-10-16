using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] float asteroidFrequencySeconds = 2f;
    [SerializeField] float frequencyIncreaseSpeed = 0.01f;
    [SerializeField] AudioSource backgroundMusic;

    float yPositionUpperBound = 10.5f;
    float xPositionHorizontalBound = 9.0f;

    public bool isGameActive;
    public enum Level { Easy, Medium, Hard }
    
    void Start()
    {
        // StartGame(Level.Easy);
    }

    public void StartGame(float level)
    {
        isGameActive = true;
        score = 0;
        asteroidFrequencySeconds -= level;

        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        UpdateScoreText(score);
        StartCoroutine(SpawnAsteroids());
        backgroundMusic.Play();
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementScore()
    {
        score += 1;
        UpdateScoreText(score);
    }

    void UpdateScoreText(int newScore)
    {
        scoreText.text = $"Score: {newScore}";
    }

    IEnumerator SpawnAsteroids()
    {
        while (isGameActive)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(asteroidFrequencySeconds);
            increaseAsteroidFrequency();
        }
    }

    void SpawnAsteroid()
    {
        Instantiate(
            asteroidPrefab,
            RandomSpawnPosition(),
            asteroidPrefab.transform.rotation
        );
    }

    Vector3 RandomSpawnPosition()
    {
        float xPosition = Random.Range(
            -xPositionHorizontalBound,
            xPositionHorizontalBound
        );

        return new Vector3(xPosition, yPositionUpperBound, 0);
    }

    void increaseAsteroidFrequency()
    {
        float newFrequency = asteroidFrequencySeconds - frequencyIncreaseSpeed;
        
        if (newFrequency > 0)
        {
            asteroidFrequencySeconds = newFrequency;
        }
    }
}
