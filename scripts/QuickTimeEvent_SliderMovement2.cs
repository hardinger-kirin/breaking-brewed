//Nick Larson
//April 15 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeEvent_SliderMovement2 : MonoBehaviour {
    float moveSpeed = 1f;
    float currentX;

    KeyCode targetKey = KeyCode.C;

    private bool this_enabled = false;
    private bool result = false;
    bool hit_vicinity = false;
    ShakeScript shake_script;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    public void change_speed(float newspeed) {
        moveSpeed = newspeed;
    }

    void Start() {
        currentX = transform.position.x;
        rb = gameObject.GetComponent<Rigidbody2D>();
        shake_script = FindObjectOfType<ShakeScript>();
    }

    public void setKey(KeyCode keyPress){
        targetKey = keyPress;
    }

    public void enable() {
        this_enabled = true;
        result = false;
    }

    public bool get_state() {
        return this_enabled;
    }

    public bool get_result() {
        return result;
    }

    // Update is called once per frame
    void Update() {   
        if(this_enabled) {
            currentX =transform.position.x;
            //Check to see if they did the quick time event
            if (Input.GetKeyDown(targetKey)) {
                if (hit_vicinity) {
                    result = true;
                } else {
                    result = false;
                    shake_script.TriggerShake();
                }

                this_enabled = false;
                } else {
                    rb.velocity = new Vector2(currentX * moveSpeed, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "hitbox") {
            hit_vicinity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "hitbox") {
            hit_vicinity = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        moveSpeed *= -1;
    }
}
