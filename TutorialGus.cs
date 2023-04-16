//Kirin Hardinger
//April 15 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGus : MonoBehaviour {
    gus_audio_script gus_script;
    int currentState = 0;

    private float text_delay = 0.05f;
    private string currentText = "";
    bool enable = true;

    GameObject textbox;
    GameObject ok;

    // Start is called before the first frame update
    void Start() {
        textbox = GameObject.Find("text");
        gus_script = FindObjectOfType<gus_audio_script>();
        ok = GameObject.Find("ok");
    }

    // Update is called once per frame
    void Update() {
        if (enable) {
            switch (currentState) {
                case 0:
                    StartCoroutine(WaitChangeText("Greetings, gentlemen. Welcome to your first day as baristas."));
                    break;
                case 1:
                    gus_script.playDiscussion();
                    StartCoroutine(WaitChangeText("As you may know, I am the manager of this establishment."));
                    break;
                case 2:
                    StartCoroutine(WaitChangeText("Gustavo Fring. Pleasure."));
                    break;
                case 3:
                    gus_script.playHelpYou();
                    StartCoroutine(WaitChangeText("Go ahead and handle a few customers on your own."));
                    break;
                case 4:
                    StartCoroutine(WaitChangeText("I'll test you afterwards myself. Should you pass..."));
                    break;
                case 5:
                    StartCoroutine(WaitChangeText("I expect you to impress the owner as well. Good luck."));
                    break;
                case 6:
                    SceneManager.LoadScene(sceneName: "MainScene");
                    break;
                default:
                    StartCoroutine(WaitChangeText(""));
                    break;
            }
        }
    }

    private IEnumerator WaitChangeText(string str) {
        enable = false;
        ok.SetActive(false);

        for (int i = 0; i < str.Length; i++) {
            currentText = str.Substring(0, i + 1);
            textbox.GetComponent<TMPro.TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(text_delay);
        }

        ok.SetActive(true);
        StartCoroutine(WaitGetKey());
    }

    private IEnumerator WaitGetKey() {
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.K)));
        enable = true;
        currentState++;
    }
}