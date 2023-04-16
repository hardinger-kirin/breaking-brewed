using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gale_audio_script : MonoBehaviour
{
    
    AudioSource muchBetter_source;
    AudioClip muchBetter;

    AudioSource quiteGood_source;
    AudioClip quiteGood;

    AudioSource presume_source;
    AudioClip presume;

    AudioSource thankYou_source;
    AudioClip thankYou;
    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();
        muchBetter_source = audio_sources[0];
        muchBetter = muchBetter_source.clip;

        quiteGood_source = audio_sources[1];
        quiteGood = quiteGood_source.clip;

        presume_source = audio_sources[2];
        presume = presume_source.clip;

        thankYou_source = audio_sources[3];
        thankYou = thankYou_source.clip;
    }
    void Update()
    {
        
    }

    public void playMuchBetter() {
        muchBetter_source.PlayOneShot(muchBetter);
    }

    public void playQuiteGood() {
        quiteGood_source.PlayOneShot(quiteGood);
    }

    public void playPresume() {
        presume_source.PlayOneShot(presume);
    }

    public void playThankYou() {
        thankYou_source.PlayOneShot(thankYou);
    }
}
