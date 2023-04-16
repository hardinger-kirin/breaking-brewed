using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mike_audio_script : MonoBehaviour
{
    AudioSource waltuh_source;
    AudioClip waltuh;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();
    
        waltuh_source=audio_sources[0];
        waltuh=waltuh_source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
