using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 0.5f;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed) {
            hasCrashed = true;
            
            if (hasCrashed) {
            FindObjectOfType<PlayerController>().DisableMovement();
            crashParticles.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", levelLoadDelay);}
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }

}
