using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jesse_audio_script : MonoBehaviour
{
    AudioSource beans_source;
    AudioClip beans;

    AudioSource hellYea_source;
    AudioClip hellYea;

    AudioSource partner_source;
    AudioClip partner;

    AudioSource yeaMrWhite_source;
    AudioClip yeaMrWhite;

    AudioSource yeaScience_source;
    AudioClip yeaScience;

    // Start is called before the first frame update
    void Start()
    {
         AudioSource[] audio_sources = GetComponents<AudioSource>();

        beans_source = audio_sources[0];
        beans = beans_source.clip;

        hellYea_source = audio_sources[1];
        hellYea = hellYea_source.clip;

        partner_source = audio_sources[2];
        partner = partner_source.clip;

        yeaMrWhite_source = audio_sources[3];
        yeaMrWhite = yeaMrWhite_source.clip;

        yeaScience_source = audio_sources[4];
        yeaScience = yeaScience_source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
