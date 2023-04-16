using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saul_audio_script : MonoBehaviour
{
    AudioSource betterCall_source;
    AudioClip betterCall;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();

        betterCall_source = audio_sources[0];
        betterCall = betterCall_source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
