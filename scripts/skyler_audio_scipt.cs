using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyler_audio_scipt : MonoBehaviour
{
    AudioSource imSkylerWhite_source;
    AudioClip imSkylerWhite;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();
        imSkylerWhite_source=audio_sources[0];
        imSkylerWhite=imSkylerWhite_source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playImSkylerWhite() {
        imSkylerWhite_source.PlayOneShot(imSkylerWhite);
    }
}
