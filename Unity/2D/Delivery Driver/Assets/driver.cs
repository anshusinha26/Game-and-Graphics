using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driver : MonoBehaviour {
    // variable to control the steer speed
    [SerializeField] float steerSpeed = 195f;
    
    // variable to control the move speed
    [SerializeField] float moveSpeed = 17f;

    // variable to boost speed by 2x
    float boostSpeed;

    // variable to boost speed by 3x
    float superBoostSpeed;

    // variable to reduce speed by -10
    float slowSpeed;

    // variable to make speed normal
    float normalSpeed;

    void Start() {
        boostSpeed = moveSpeed * 2;
        superBoostSpeed = moveSpeed * 3;
        slowSpeed = moveSpeed - 10;
        normalSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update() {
        // variable to control the steer amount via keyboard
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // Time.deltaTime - used to make the movement frame rate independent
        // variable to control the move amount via keyboard
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // rotate the car
        transform.Rotate(0, 0, -steerAmount);
        // move the car
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "s2x") {
            moveSpeed = boostSpeed;
            Debug.Log("Speed boosted by 2x!");
        }

        if (other.tag == "s3x") {
            moveSpeed = superBoostSpeed;
            Debug.Log("Speed boosted by 3x!");
        }

        if (other.tag == "s-10") {
            moveSpeed = slowSpeed;
            Debug.Log("Speed reduced by 10!");
        }

        if (other.tag == "sn") {
            moveSpeed = normalSpeed;
            Debug.Log("Speed back to normal!");
        }
    }
}