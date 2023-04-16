//Kirin Hardinger
//April 15 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {
    //p1 assets
    GameObject p1_machine;
    GameObject p1_espresso;
    GameObject p1_coffee;
    GameObject TextCanvas1;
    GameObject ok1;
    GameObject text1;
    GameObject c_key;
    GameObject s_key;
    GameObject e_key;
    GameObject w_key;
    GameObject mini_game1;
    QuickTimeEvent_SliderMovement minigame1;
    private bool flag = false;
    public Sprite full_coffee;
    public Sprite empty_coffee;
    public Sprite full_espresso;
    public Sprite empty_espresso;
    GameObject hank;
    bool hank_outcome = false;
    GameObject saul;
    bool saul_outcome = false;
    GameObject jesse;
    bool jesse_outcome = false;
    int p1_state = 0;
    bool p1_enable = true;
    string p1_currentText = "";
    private float text_delay = 0.05f;
    hank_audio_script hank_script;
    saul_audio_script saul_script;
    jesse_audio_script jesse_script;
    SFX_audio_script audio_script;

    private void Start() {
        audio_script = FindObjectOfType<SFX_audio_script>();
        //initialize
        initialize();
    }

    public int get_p1() {
        return p1_state;
    }

    private void Update() {
        if(p1_enable) {
            switch (p1_state) {
                case 0:
                    jesse.SetActive(true);
                    TextCanvas1.SetActive(true);
                    StartCoroutine(WaitChangeText1("Yo! Don't question why there's two of me."));
                    break;
                case 1:
                    jesse_script.playBeans();
                    StartCoroutine(WaitChangeText1("Gimme uhh... some coffee beans."));
                    break;
                case 2:
                    jesse_script.playYeaScience();
                    StartCoroutine(WaitChangeText1("SIKE! Haha. Gimme a coffee with sugar."));
                    break;
                case 3:
                    TextCanvas1.SetActive(false);
                    p1_coffee.SetActive(true);
                    c_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP1Move(KeyCode.C));
                    break;
                case 4:
                    mini_game1.SetActive(true);
                    if(flag) {
                        flag = false;
                        minigame1.enable();
                    }
                    p1_state++;
                    break;
                case 5:
                    audio_script.playFillingCup();
                    if(!minigame1.get_state()) {
                        c_key.SetActive(false);
                        p1_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game1.SetActive(false);
                        jesse_outcome = minigame1.get_result();
                        s_key.SetActive(true);
                        StartCoroutine(WaitP1Move(KeyCode.S));
                    }
                    break;
                case 6:
                    audio_script.playGlassClink();
                    TextCanvas1.SetActive(true);
                    s_key.SetActive(false);
                    audio_script.playDrinkSip();
                    if (jesse_outcome) {
                        jesse_script.playHellYea();
                        StartCoroutine(WaitChangeText1("Damn! That's some good shit. See ya."));
                    }
                    else {
                        StartCoroutine(WaitChangeText1("That tastes like ass, yo. See ya."));
                    }
                    break;
                case 7:
                    jesse.SetActive(false);
                    p1_coffee.SetActive(false);
                    hank.SetActive(true);
                    TextCanvas1.SetActive(true);
                    StartCoroutine(WaitChangeText1("Haha, hey Walt! Car wash didn't work out, huh?"));
                    break;
                case 8:
                    StartCoroutine(WaitChangeText1("Ahh I'm just playin' with ya."));
                    break;
                case 9:
                    StartCoroutine(WaitChangeText1("How about you grab me an espresso with a little milk?"));
                    break;
                case 10:
                    TextCanvas1.SetActive(false);
                    p1_espresso.GetComponent<SpriteRenderer>().sprite = empty_espresso;
                    p1_espresso.SetActive(true);
                    e_key.SetActive(true);
                    StartCoroutine(WaitP1Move(KeyCode.E));
                    flag = true;
                    break;
                case 11:
                    mini_game1.SetActive(true);
                    minigame1.setKey(KeyCode.E);
                    if (flag) {
                        flag = false;
                        minigame1.enable();
                    }
                    p1_state++;
                    break;
                case 12:
                    audio_script.playFillingCup();
                    if (!minigame1.get_state()) {
                        e_key.SetActive(false);
                        p1_espresso.GetComponent<SpriteRenderer>().sprite = full_espresso;
                        mini_game1.SetActive(false);
                        hank_outcome = minigame1.get_result();
                        w_key.SetActive(true);
                        StartCoroutine(WaitP1Move(KeyCode.W));
                    }
                    break;
                case 13:
                    audio_script.playGlassClink();
                    audio_script.playDrinkSip();
                    TextCanvas1.SetActive(true);
                    w_key.SetActive(false);

                    if (hank_outcome) {
                        hank_script.playmugMoment();
                        StartCoroutine(WaitChangeText1("You're like a chemist but with coffee. Mug moment!"));
                    }
                    else {
                        StartCoroutine(WaitChangeText1("Maybe you should try going back to the car wash... Adios!"));
                    }
                    break;
                case 14:
                    hank.SetActive(false);
                    p1_espresso.SetActive(false);
                    saul.SetActive(true);
                    TextCanvas1.SetActive(true);
                    StartCoroutine(WaitChangeText1("If it isn't my favorite client!"));
                    break;
                case 15:
                    StartCoroutine(WaitChangeText1("Fell pretty hard from grace, huh?"));
                    break;
                case 16:
                    StartCoroutine(WaitChangeText1("Anyways, just a black coffee, thanks. Simple."));
                    break;
                case 17:
                    TextCanvas1.SetActive(false);
                    p1_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p1_coffee.SetActive(true);
                    c_key.SetActive(true);
                    StartCoroutine(WaitP1Move(KeyCode.C));
                    flag = true;
                    break;
                case 18:
                    mini_game1.SetActive(true);
                    minigame1.setKey(KeyCode.C);
                    if (flag) {
                        flag = false;
                        minigame1.enable();
                    }
                    p1_state++;
                    break;
                case 19:
                    audio_script.playFillingCup();
                    if (!minigame1.get_state()) {
                        audio_script.playGlassClink();
                        audio_script.playDrinkSip();
                        c_key.SetActive(false);
                        p1_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game1.SetActive(false);
                        saul_outcome = minigame1.get_result();
                        TextCanvas1.SetActive(true);

                        if (saul_outcome) {
                            saul_script.playBetterCall();
                            StartCoroutine(WaitChangeText1("Just how I like it. Call me!"));
                        }
                        else {
                            StartCoroutine(WaitChangeText1("You better NOT call Saul from now on..."));
                        }
                    }
                    break;
                case 20:
                    saul.SetActive(false);
                    p1_coffee.SetActive(false);
                    TextCanvas1.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator WaitP1Move(KeyCode expected) {
        p1_enable = false;
        yield return new WaitUntil(() => Input.GetKeyDown(expected));
        p1_enable = true;
        p1_state++;
    }

    private IEnumerator WaitChangeText1(string str) {
        p1_enable = false;
        ok1.SetActive(false);

        for (int i = 0; i < str.Length; i++) {
            p1_currentText = str.Substring(0, i + 1);
            text1.GetComponent<TMPro.TextMeshProUGUI>().text = p1_currentText;
            yield return new WaitForSeconds(text_delay);
        }

        ok1.SetActive(true);
        StartCoroutine(WaitGetKey1());
    }

    private IEnumerator WaitGetKey1() {
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.C)));
        p1_enable = true;
        p1_state++;
    }

    private void initialize() {
        p1_machine = GameObject.Find("machine1");
        p1_espresso = GameObject.Find("espresso1");
        p1_coffee = GameObject.Find("coffee1");
        TextCanvas1 = GameObject.Find("TextCanvas1");
        ok1 = GameObject.Find("ok1");
        text1 = GameObject.Find("text1");
        c_key = GameObject.Find("c_key");
        s_key = GameObject.Find("s_key");
        e_key = GameObject.Find("e_key");
        w_key = GameObject.Find("w_key");
        mini_game1 = GameObject.Find("Minigame1");
        minigame1 = FindObjectOfType<QuickTimeEvent_SliderMovement>();
        hank_script = FindObjectOfType<hank_audio_script>();
        saul_script = FindObjectOfType<saul_audio_script>();
        jesse_script = FindObjectOfType<jesse_audio_script>();

        hank = GameObject.Find("hank");
        saul = GameObject.Find("saul");
        jesse = GameObject.Find("jesse");

        setInactives();
    }

    private void setInactives() {
        p1_espresso.SetActive(false);
        p1_coffee.SetActive(false);
        TextCanvas1.SetActive(false);
        ok1.SetActive(false);
        c_key.SetActive(false);
        s_key.SetActive(false);
        e_key.SetActive(false);
        w_key.SetActive(false);
        mini_game1.SetActive(false);

        hank.SetActive(false);
        saul.SetActive(false);
        jesse.SetActive(false);
    }
}