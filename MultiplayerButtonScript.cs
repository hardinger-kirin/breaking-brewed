//Kirin Hardinger
//April 15 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerButtonScript : MonoBehaviour {
    GameObject jesser;

    // Start is called before the first frame update
    void Start() {
        jesser = GameObject.Find("Jesser");
        jesser.SetActive(false);
    }

    public void Multiplayer(int sceneID) {
        jesser.SetActive(true);

        //play some kinda jesse audio

        StartCoroutine(WaitChange(2, sceneID));
    }

    void ChangeScene(int sceneID) {
        SceneManager.LoadScene(sceneID);
    }

    private IEnumerator WaitChange(float waitTime, int sceneID) {
        yield return new WaitForSecondsRealtime(waitTime);
        ChangeScene(sceneID);
    }
}