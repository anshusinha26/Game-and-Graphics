using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour {
    // variable to check if player has package
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32 (0, 255, 32, 255);
    [SerializeField] Color32 noPackageColor = new Color32 (255, 255, 255, 255);

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "package" && !hasPackage) {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package picked up!");
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "customer" && hasPackage) {   
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package delivered!");
            hasPackage = false;
        }
    }
}
