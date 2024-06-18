using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0.5f;
    [SerializeField] ParticleSystem finishParticles;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            finishParticles.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", levelLoadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
