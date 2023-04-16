using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEffect : MonoBehaviour
{
    public bool effectStatus = true;

    float scaleSpeed = 0.005f;
    float startScale;
    float maxScale, minScale;
    bool growing = true;

    void Start(){
        startScale = transform.localScale.x;
        minScale = startScale * 0.89f;
        maxScale = startScale * 1.11f;
        Debug.Log(startScale);
        Debug.Log(maxScale);
    }
    void Update()
    {
        if(effectStatus){
            if(growing && transform.localScale.x < maxScale){
                transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0);
            }
            else if (!growing && transform.localScale.x > minScale){
                transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, 0);
            }
            else{
                growing = !growing;
            }
        }
    }

    public void enableScale(){
        effectStatus = true;
    }

    public void disableScale(){
        effectStatus = false;
    }
}
