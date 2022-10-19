using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticleSystem;
    
    AudioSource explosionAudio;
    GameOverUIManager gameOverUIManager;

    // Start is called before the first frame update
    void Start()
    {
        explosionAudio = GameObject.Find("Earth Strike Audio Source").GetComponent<AudioSource>();
        gameOverUIManager = GameObject.Find("Game Over UI Manager").GetComponent<GameOverUIManager>();
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Earth"))
        {
            Explode();
            gameOverUIManager.TriggerGameOver();
        }
    }

    void Explode()
    {
        ParticleSystem explosionParticle = Instantiate(explosionParticleSystem, transform.position, transform.rotation);
        explosionParticle.Play();
        explosionAudio.Play();
    }
}
