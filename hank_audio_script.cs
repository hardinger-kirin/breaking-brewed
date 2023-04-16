using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hank_audio_script : MonoBehaviour
{
    AudioSource mugMoment_source;
    AudioClip mugMoment;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();

        mugMoment_source = audio_sources[0];
        mugMoment = mugMoment_source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playmugMoment() {
        mugMoment_source.PlayOneShot(mugMoment);
    }
}
