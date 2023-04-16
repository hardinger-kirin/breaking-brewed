using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This was done by following this tutorial: https://www.youtube.com/watch?v=Ox0JCbVIMCQ

public class SceneFading : MonoBehaviour
{

    public CanvasGroup fading;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public float fadeSpeed;

    // Update is called once per frame
    void Update()
    {
        if (fadeIn == true){
            if(fading.alpha < 1){
                fading.alpha += fadeSpeed * Time.deltaTime;
                if(fading.alpha >= 1){
                    fadeIn = false;
                }

            }
        }
        if (fadeOut == true){
            if(fading.alpha >= 0){
                fading.alpha -= fadeSpeed * Time.deltaTime;
                if(fading.alpha == 0){
                    fadeOut = false;
                }

            }
        }
    }

    public void setFadeIn(){
        fadeIn = true;
    }

    public void setFadeOut(){
        fadeOut = true;
    }
}
