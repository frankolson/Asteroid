using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] float frequencyIncreaseSpeed = 0.01f;

    float asteroidFrequencySeconds = 2f;
    float yPositionUpperBound = 10.5f;
    float xPositionHorizontalBound = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        SetAsteroidFrequency();
        StartCoroutine(SpawnAsteroids());
    }

    private void SetAsteroidFrequency()
    {
        asteroidFrequencySeconds -= GameManager.Instance.CurrentLevel;
    }

    IEnumerator SpawnAsteroids()
    {
        while (GameManager.Instance.IsGameActive)
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
