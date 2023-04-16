//Kirin Hardinger
//April 15 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript2 : MonoBehaviour {
    GameObject n_key;
    GameObject u_key;
    GameObject o_key;
    GameObject p_key;
    GameObject mini_game2;
    QuickTimeEvent_SliderMovement2 minigame2;
    private bool flag = false;
    public Sprite full_coffee;
    public Sprite empty_coffee;
    public Sprite full_espresso;
    public Sprite empty_espresso;
    GameObject p2_machine;
    GameObject p2_espresso;
    GameObject p2_coffee;
    GameObject TextCanvas2;
    GameObject ok2;
    GameObject text2;
    GameObject marie;
    bool marie_outcome = false;
    GameObject skyler;
    bool skyler_outcome = false;
    GameObject jr;
    bool jr_outcome = false;
    int p2_state = 0;
    bool p2_enable = true;
    string p2_currentText = "";
    private float text_delay = 0.05f;
    skyler_audio_scipt skyler_script;
    marie_audio_script marie_script;
    waltjr_audio_script jr_script;
    SFX_audio_script audio_script;

    private void Start() {
        audio_script = FindObjectOfType<SFX_audio_script>();
        //initialize
        initialize();
    }

    public int get_p2() {
        return p2_state;
    }

    private void Update() {
        if (p2_enable) {
            switch (p2_state) {
                case 0:
                    marie.SetActive(true);
                    TextCanvas2.SetActive(true);
                    StartCoroutine(WaitChangeText2("Oh! A young man!"));
                    break;
                case 1:
                    marie_script.playMyHusband();
                    StartCoroutine(WaitChangeText2("Are you sure you're qualified...?"));
                    break;
                case 2:
                    StartCoroutine(WaitChangeText2("Whatever. I'll have an espresso with milk and sugar."));
                    break;
                case 3:
                    TextCanvas2.SetActive(false);
                    p2_espresso.SetActive(true);
                    u_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP2Move(KeyCode.U));
                    break;
                case 4:
                    mini_game2.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame2.setKey(KeyCode.U);
                        minigame2.enable();
                    }
                    p2_state++;
                    break;
                case 5:
                    audio_script.playFillingCup();
                    if (!minigame2.get_state()) {
                        u_key.SetActive(false);
                        p2_espresso.GetComponent<SpriteRenderer>().sprite = full_espresso;
                        mini_game2.SetActive(false);
                        marie_outcome = minigame2.get_result();
                        o_key.SetActive(true);
                        StartCoroutine(WaitP2Move(KeyCode.O));
                    }
                    break;
                case 6:
                    o_key.SetActive(false);
                    p_key.SetActive(true);
                    StartCoroutine(WaitP2Move(KeyCode.P));
                    break;
                case 7:
                    p_key.SetActive(false);
                    TextCanvas2.SetActive(true);
                    audio_script.playGlassClink();
                    audio_script.playDrinkSip();
                    if (marie_outcome) {
                        StartCoroutine(WaitChangeText2("Well, prove me wrong I guess! Good job."));
                    }
                    else {
                        StartCoroutine(WaitChangeText2("Just what I thought... Disgusting."));
                    }
                    break;
                case 8:
                    marie.SetActive(false);
                    p2_espresso.SetActive(false);
                    skyler.SetActive(true);
                    TextCanvas2.SetActive(true);
                    StartCoroutine(WaitChangeText2("Sorry, my sister can be... not the nicest sometimes..."));
                    break;
                case 9:
                    StartCoroutine(WaitChangeText2("Wait a second. You're that Pinkman kid."));
                    break;
                case 10:
                    skyler_script.playImSkylerWhite();
                    StartCoroutine(WaitChangeText2("Do not sell coffee to my husband. Get me a black coffee."));
                    break;
                case 11:
                    TextCanvas2.SetActive(false);
                    p2_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p2_coffee.SetActive(true);
                    n_key.SetActive(true);
                    StartCoroutine(WaitP2Move(KeyCode.N));
                    flag = true;
                    break;
                case 12:
                    mini_game2.SetActive(true);
                    minigame2.setKey(KeyCode.N);
                    if (flag) {
                        flag = false;
                        minigame2.enable();
                    }
                    p2_state++;
                    break;
                case 13:
                    audio_script.playFillingCup();
                    if (!minigame2.get_state()) {
                        n_key.SetActive(false);
                        p2_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game2.SetActive(false);
                        skyler_outcome = minigame2.get_result();
                        TextCanvas2.SetActive(true);
                        if (skyler_outcome) {
                            audio_script.playGlassClink();
                            audio_script.playDrinkSip();
                            StartCoroutine(WaitChangeText2("Uh-huh. Good to know you learned your lesson."));
                        }
                        else {
                            StartCoroutine(WaitChangeText2("Junkie rats like you never change."));
                        }
                    }
                    break;
                case 14:
                    skyler.SetActive(false);
                    p2_espresso.SetActive(false);
                    jr.SetActive(true);
                    TextCanvas2.SetActive(true);
                    StartCoroutine(WaitChangeText2("Oh. Hi. Are you working with my dad?"));
                    break;
                case 15:
                    jr_script.playPussy();
                    StartCoroutine(WaitChangeText2("That's kinda weird... Okay..."));
                    break;
                case 16:
                    StartCoroutine(WaitChangeText2("Espresso with milk and sugar please."));
                    break;
                case 17:
                    TextCanvas2.SetActive(false);
                    p2_espresso.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p2_espresso.SetActive(true);
                    u_key.SetActive(true);
                    StartCoroutine(WaitP2Move(KeyCode.U));
                    flag = true;
                    break;
                case 18:
                    mini_game2.SetActive(true);
                    minigame2.setKey(KeyCode.U);
                    if (flag) {
                        flag = false;
                        minigame2.enable();
                    }
                    p2_state++;
                    break;
                case 19:
                    audio_script.playFillingCup();
                    if (!minigame2.get_state()) {
                        u_key.SetActive(false);
                        p2_espresso.GetComponent<SpriteRenderer>().sprite = full_espresso;
                        mini_game2.SetActive(false);
                        jr_outcome = minigame2.get_result();
                        o_key.SetActive(true);
                        StartCoroutine(WaitP2Move(KeyCode.O));
                    }
                    break;
                case 20:
                    o_key.SetActive(false);
                    p_key.SetActive(true);
                    StartCoroutine(WaitP2Move(KeyCode.P));
                    break;
                case 21:
                    p_key.SetActive(false);
                    TextCanvas2.SetActive(true);
                    audio_script.playGlassClink();
                    audio_script.playDrinkSip();

                    if (jr_outcome) {
                        StartCoroutine(WaitChangeText2("Thanks! I guess you're not that weird."));
                    }
                    else {
                        StartCoroutine(WaitChangeText2("You better not rub off on my dad... It's bad enough."));
                    }
                    break;
                case 22:
                    jr.SetActive(false);
                    p2_espresso.SetActive(false);
                    TextCanvas2.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator WaitChangeText2(string str) {
        p2_enable = false;
        ok2.SetActive(false);

        for (int i = 0; i < str.Length; i++) {
            p2_currentText = str.Substring(0, i + 1);
            text2.GetComponent<TMPro.TextMeshProUGUI>().text = p2_currentText;
            yield return new WaitForSeconds(text_delay);
        }

        ok2.SetActive(true);
        StartCoroutine(WaitGetKey2());
    }

    private IEnumerator WaitGetKey2() {
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.K)));
        p2_enable = true;
        p2_state++;
    }

    private IEnumerator WaitP2Move(KeyCode expected) {
        p2_enable = false;
        yield return new WaitUntil(() => Input.GetKeyDown(expected));
        p2_enable = true;
        p2_state++;
    }

    private void initialize() {
        n_key = GameObject.Find("n_key");
        u_key = GameObject.Find("u_key");
        o_key = GameObject.Find("o_key");
        p_key = GameObject.Find("p_key");
        mini_game2 = GameObject.Find("Minigame2");
        minigame2 = FindObjectOfType<QuickTimeEvent_SliderMovement2>();
        p2_machine = GameObject.Find("machine2");
        p2_espresso = GameObject.Find("espresso2");
        p2_coffee = GameObject.Find("coffee2");
        TextCanvas2 = GameObject.Find("TextCanvas2");
        ok2 = GameObject.Find("ok2");
        text2 = GameObject.Find("text2");
        marie = GameObject.Find("marie");
        skyler = GameObject.Find("skyler");
        jr = GameObject.Find("jr");
        skyler_script = FindObjectOfType<skyler_audio_scipt>();
        marie_script = FindObjectOfType<marie_audio_script>();
        jr_script = FindObjectOfType<waltjr_audio_script>();
        setInactives();
    }

    private void setInactives() {
        n_key.SetActive(false);
        u_key.SetActive(false);
        o_key.SetActive(false);
        p_key.SetActive(false);
        mini_game2.SetActive(false);
        p2_espresso.SetActive(false);
        p2_coffee.SetActive(false);
        TextCanvas2.SetActive(false);
        ok2.SetActive(false);
        marie.SetActive(false);
        skyler.SetActive(false);
        jr.SetActive(false);
    }
}