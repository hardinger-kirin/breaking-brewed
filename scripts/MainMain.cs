//Kirin Hardinger
//April 15 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMain : MonoBehaviour {
    MainScript main_script;
    MainScript2 main_script2;

    private void Start() {
        main_script = FindObjectOfType<MainScript>();
        main_script2 = FindObjectOfType<MainScript2>();
    }

    // Update is called once per frame
    void Update() {
        if(main_script.get_p1() >= 20 && main_script2.get_p2() >= 22) {
            SceneManager.LoadScene(sceneName: "BossScene");
        }
    }
}
