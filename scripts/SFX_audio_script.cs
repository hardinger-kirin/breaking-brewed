using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_audio_script : MonoBehaviour
{
    AudioSource glassClink_source;
    AudioClip  glassClink;

    AudioSource grindingBeans_source;
    AudioClip grindingBeans;

    AudioSource drinkSip_source;
    AudioClip drinkSip;

    AudioSource fillingCup_source;
    AudioClip fillingCup;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio_sources = GetComponents<AudioSource>();

        glassClink_source=audio_sources[0];
        glassClink=glassClink_source.clip;

        grindingBeans_source=audio_sources[1];
        grindingBeans=grindingBeans_source.clip;
        
        fillingCup_source=audio_sources[2];
        fillingCup=fillingCup_source.clip;

        drinkSip_source=audio_sources[3];
        drinkSip=drinkSip_source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void playGlassClink() {
        glassClink_source.PlayOneShot(glassClink);
    }

    public void playGrindingBeans() {
        grindingBeans_source.PlayOneShot(grindingBeans);
    }

    public void playDrinkSip() {
        drinkSip_source.PlayOneShot(drinkSip);
    }

    public void playFillingCup() {
        fillingCup_source.PlayOneShot(fillingCup);
    }
}
