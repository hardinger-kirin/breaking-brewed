using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour {
    private Transform trans;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 2f;
    private float dampingSpeed = 1.0f;
    Vector3 initialPosition;

    void Awake() {
        if (trans == null) {
            trans = GetComponent(typeof(Transform)) as Transform;
        }
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (shakeDuration > 0) {
            trans.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else {
            shakeDuration = 0f;
            trans.localPosition = initialPosition;
        }
    }

    void OnEnable() {
        initialPosition = trans.localPosition;
    }

    public void TriggerShake() {
        shakeDuration = 0.8f;
    }
}