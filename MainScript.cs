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
    bool flag = false;

    public Sprite full_coffee;
    public Sprite empty_coffee;
    public Sprite full_espresso;
    public Sprite empty_espresso;

    //p2 assets
    GameObject p2_machine;
    GameObject p2_espresso;
    GameObject p2_coffee;
    GameObject TextCanvas2;
    GameObject ok2;
    GameObject text2;

    GameObject hank;
    bool hank_outcome = false;
    GameObject saul;
    bool saul_outcome = false;
    GameObject jesse;
    bool jesse_outcome = false;

    GameObject marie;
    GameObject skyler;
    GameObject jr;

    int p1_state = 0;
    int p2_state = 0;

    bool p1_enable = true;
    bool p2_enable = true;

    string p1_currentText = "";
    string p2_currentText = "";

    private float text_delay = 0.05f;

    private void Start() {
        //initialize
        initialize();
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
                    StartCoroutine(WaitChangeText1("Gimme uhh... some coffee beans."));
                    break;
                case 2:
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
                    //coffee pour sound
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
                    TextCanvas1.SetActive(true);
                    s_key.SetActive(false);

                    if (jesse_outcome) {
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
                    //espresso pour sound
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
                    TextCanvas1.SetActive(true);
                    w_key.SetActive(false);

                    if (hank_outcome) {
                        StartCoroutine(WaitChangeText1("Hooooeee! You're like a meth cooker but with coffee. Adios!"));
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
                    //coffee pour sound
                    if (!minigame1.get_state()) {
                        c_key.SetActive(false);
                        p1_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game1.SetActive(false);
                        saul_outcome = minigame1.get_result();
                        TextCanvas1.SetActive(true);

                        if (saul_outcome) {
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

        if(p2_enable) {
            switch(p2_state) {
                //
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

        p2_machine = GameObject.Find("machine2");
        p2_espresso = GameObject.Find("espresso2");
        p2_coffee = GameObject.Find("coffee2");
        TextCanvas2 = GameObject.Find("TextCanvas2");
        ok2 = GameObject.Find("ok2");
        text2 = GameObject.Find("text2");

        hank = GameObject.Find("hank");
        saul = GameObject.Find("saul");
        jesse = GameObject.Find("jesse");

        marie = GameObject.Find("marie");
        skyler = GameObject.Find("skyler");
        jr = GameObject.Find("jr");

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

        p2_espresso.SetActive(false);
        p2_coffee.SetActive(false);
        TextCanvas2.SetActive(false);
        ok2.SetActive(false);

        hank.SetActive(false);
        saul.SetActive(false);
        jesse.SetActive(false);

        marie.SetActive(false);
        skyler.SetActive(false);
        jr.SetActive(false);
    }
}