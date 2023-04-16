using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marie_audio_script : MonoBehaviour
{
    AudioSource myHusband_source;
    AudioClip myHusband;

    // Start is called before the first frame update
    void Start()
    {
      AudioSource[] audio_sources = GetComponents<AudioSource>();

      myHusband_source = audio_sources[0];
      myHusband = myHusband_source.clip;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMyHusband() {
        myHusband_source.PlayOneShot(myHusband);
    }
}
