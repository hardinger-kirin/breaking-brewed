using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{

    VideoPlayer introVideo;
    float time;
    float timeDelay;

    void Start() {
        introVideo = gameObject.GetComponent<VideoPlayer>();
        time = 0f;
        timeDelay = 3f;
    }
    // Update is called once per frame
    void Update()
    {
        time = time + 1f*Time.deltaTime;
        if(time>timeDelay){
            if(!introVideo.isPlaying){
            SceneManager.LoadScene(sceneName: "StartMenuScene");
       } 
        }

    }
}