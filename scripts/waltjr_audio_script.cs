using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waltjr_audio_script : MonoBehaviour
{
    AudioSource pussy_source;
    AudioClip pussy;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();

        pussy_source = audio_sources[0];
        pussy=pussy_source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playPussy() {
        pussy_source.PlayOneShot(pussy);
    }
}

