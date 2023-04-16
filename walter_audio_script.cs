using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walter_audio_script : MonoBehaviour
{
    AudioSource bestCoffee_source;
    AudioClip bestCoffee;

    AudioSource iAmTheCoffee_source;
    AudioClip iAmTheCoffee;

    AudioSource imTheCook_source;
    AudioClip imTheCook;

    AudioSource victoryLaugh_source;
    AudioClip victoryLaugh;

    AudioSource soSeriously_source;
    AudioClip soSeriously;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();

        bestCoffee_source = audio_sources[0];
        bestCoffee = bestCoffee_source.clip;

        iAmTheCoffee_source = audio_sources[1];
        iAmTheCoffee = iAmTheCoffee_source.clip;

        imTheCook_source = audio_sources[2];
        imTheCook = imTheCook_source.clip;

        victoryLaugh_source = audio_sources[3];
        victoryLaugh = victoryLaugh_source.clip;

        soSeriously_source = audio_sources[4];
        soSeriously = soSeriously_source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
