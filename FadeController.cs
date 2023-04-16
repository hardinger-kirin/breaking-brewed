using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{

    SceneFading Fade;
    // Start is called before the first frame update
    void Start()
    {
        Fade = FindObjectOfType<SceneFading>();

        Fade.setFadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
