using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMissileStrike : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticleSystem;
    private GameManager gameManager;
    private AudioSource explosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        explosionAudio = GameObject.Find("Missile Strike Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            Explode();
            gameManager.IncrementScore();
        }
    }

    private void Explode()
    {
        ParticleSystem explosionParticle = Instantiate(explosionParticleSystem, transform.position, transform.rotation);
        explosionParticle.Play();
        explosionAudio.Play();
    }
}
