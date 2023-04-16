using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gus_audio_script : MonoBehaviour
{
    AudioSource discussion_source;
    AudioClip discussion;

    AudioSource offer_source;
    AudioClip offer;

    AudioSource interfere_source;
    AudioClip interfere;

    AudioSource partTime_source;
    AudioClip partTime;

    AudioSource helpYou_source;
    AudioClip helpYou;

    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();

        discussion_source = audio_sources[0];
        discussion = discussion_source.clip;

        offer_source = audio_sources[1];
        offer = offer_source.clip;

        interfere_source = audio_sources[2];
        interfere = interfere_source.clip;

        partTime_source = audio_sources[3];
        partTime = discussion_source.clip;

        helpYou_source = audio_sources[4];
        helpYou = helpYou_source.clip;
        
    }
    void Update()
    {
        
    }
}
