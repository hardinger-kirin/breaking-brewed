using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtrack_audio_script : MonoBehaviour
{

    AudioSource gameSong_source;
    AudioClip gameSong;

    AudioSource gusTheme_source;
    AudioClip gusTheme;

    AudioSource galeTheme_source;
    AudioClip galeTheme;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();

        gameSong_source=audio_sources[0];
        gameSong=gameSong_source.clip;

        gusTheme_source=audio_sources[1];
        gusTheme=gusTheme_source.clip;

        galeTheme_source=audio_sources[2];
        galeTheme=galeTheme_source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGameSong() {
        gameSong_source.PlayOneShot(gameSong);
    }

    public void playGusTheme() {
        gusTheme_source.PlayOneShot(gusTheme);
    }

    public void playgaleTheme() {
        galeTheme_source.PlayOneShot(galeTheme);
    }
}
