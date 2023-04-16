//Kirin Hardinger
//April 16 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle1 : MonoBehaviour {
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
    int p1_state = 0;
    bool p1_enable = true;
    string p1_currentText = "";
    private float text_delay = 0.05f;
    bool gus_flag = false;
    bool gus_outcome = false;
    bool mike_flag = false;
    bool mike_outcome = false;
    bool gale_flag = false;
    bool gale_outcome = false;

    private void Start() {
        //initialize
        initialize();
    }

    public int get_p1() {
        return p1_state;
    }

    public void set_gus_flag(bool flag) {
        gus_flag = flag;
    }

    public void set_mike_flag(bool flag) {
        mike_flag = flag;
    }
    public void set_gale_flag(bool flag) {
        gale_flag = flag;
    }

    // Update is called once per frame
    void Update() {
        if (gus_flag && p1_enable) {
            switch (p1_state) {
                case 0:
                    minigame1.change_speed(1.7f);
                    TextCanvas1.SetActive(true);
                    StartCoroutine(WaitChangeText1("A black coffee."));
                    break;
                case 1:
                    TextCanvas1.SetActive(false);
                    p1_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p1_coffee.SetActive(true);
                    c_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP1Move(KeyCode.C));
                    break;
                case 2:
                    minigame1.setKey(KeyCode.C);
                    mini_game1.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame1.enable();
                    }
                    p1_state++;
                    break;
                case 3:
                    //coffee pour sound
                    if (!minigame1.get_state()) {
                        c_key.SetActive(false);
                        p1_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game1.SetActive(false);
                        gus_outcome = minigame1.get_result();

                        if (!gus_outcome) {
                            SceneManager.LoadScene(sceneName: "LoseScene");
                        }

                        TextCanvas1.SetActive(true);
                        StartCoroutine(WaitChangeText1("Good. Now an espresso with milk."));
                    }
                    break;
                case 4:
                    TextCanvas1.SetActive(false);
                    p1_coffee.SetActive(false);
                    p1_espresso.GetComponent<SpriteRenderer>().sprite = empty_espresso;
                    p1_espresso.SetActive(true);
                    e_key.SetActive(true);
                    StartCoroutine(WaitP1Move(KeyCode.E));
                    flag = true;
                    break;
                case 5:
                    mini_game1.SetActive(true);
                    minigame1.setKey(KeyCode.E);
                    if (flag) {
                        flag = false;
                        minigame1.enable();
                    }
                    p1_state++;
                    break;
                case 6:
                    //espresso pour sound
                    if (!minigame1.get_state()) {
                        e_key.SetActive(false);
                        p1_espresso.GetComponent<SpriteRenderer>().sprite = full_espresso;
                        mini_game1.SetActive(false);
                        gus_outcome = minigame1.get_result();

                        if (!gus_outcome) {
                            SceneManager.LoadScene(sceneName: "LoseScene");
                        }

                        w_key.SetActive(true);
                        StartCoroutine(WaitP1Move(KeyCode.W));
                    }
                    break;
                case 7:
                    w_key.SetActive(false);
                    gus_flag = false;
                    p1_state++;
                    break;
                default:
                    break;
            }
        }
        else if (mike_flag && p1_enable) {
            switch (p1_state) {
                case 8:
                    minigame1.change_speed(1f);
                    TextCanvas1.SetActive(true);
                    StartCoroutine(WaitChangeText1("A black coffee."));
                    break;
                case 9:
                    TextCanvas1.SetActive(false);
                    p1_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p1_coffee.SetActive(true);
                    c_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP1Move(KeyCode.C));
                    break;
                case 10:
                    minigame1.setKey(KeyCode.C);
                    mini_game1.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame1.enable();
                    }
                    p1_state++;
                    break;
                case 11:
                    //coffee pour sound
                    if (!minigame1.get_state()) {
                        c_key.SetActive(false);
                        p1_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game1.SetActive(false);
                        mike_outcome = minigame1.get_result();
                    }
                    mike_flag = false;
                    p1_state++;
                    break;
            }
        }
        else if (gale_flag && p1_enable) {
            switch(p1_state) {
                case 12:
                    minigame1.change_speed(1.7f);
                    TextCanvas1.SetActive(true);
                    StartCoroutine(WaitChangeText1("A coffee with cream and sugar."));
                    break;
                case 13:
                    TextCanvas1.SetActive(false);
                    p1_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p1_coffee.SetActive(true);
                    c_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP1Move(KeyCode.C));
                    break;
                case 14:
                    minigame1.setKey(KeyCode.C);
                    mini_game1.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame1.enable();
                    }
                    p1_state++;
                    break;
                case 15:
                    //coffee pour sound
                    if (!minigame1.get_state()) {
                        c_key.SetActive(false);
                        p1_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game1.SetActive(false);
                        gale_outcome = minigame1.get_result();

                        if(!gale_outcome) {
                            SceneManager.LoadScene(sceneName: "LoseScene");
                        }

                        w_key.SetActive(true);
                        StartCoroutine(WaitP1Move(KeyCode.W));
                    }
                    break;
                case 16:
                    w_key.SetActive(false);
                    s_key.SetActive(true);
                    StartCoroutine(WaitP1Move(KeyCode.S));
                    break;
                case 17:
                    s_key.SetActive(false);
                    p1_coffee.SetActive(false);
                    TextCanvas1.SetActive(true);
                    StartCoroutine(WaitChangeText1("An espresso with sugar."));
                    break;
                case 18:
                    TextCanvas1.SetActive(false);
                    p1_espresso.GetComponent<SpriteRenderer>().sprite = empty_espresso;
                    p1_espresso.SetActive(true);
                    e_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP1Move(KeyCode.E));
                    break;
                case 19:
                    minigame1.setKey(KeyCode.E);
                    mini_game1.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame1.enable();
                    }
                    p1_state++;
                    break;
                case 20:
                    //coffee pour sound
                    if (!minigame1.get_state()) {
                        e_key.SetActive(false);
                        p1_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game1.SetActive(false);
                        gale_outcome = minigame1.get_result();

                        if (!gale_outcome) {
                            SceneManager.LoadScene(sceneName: "LoseScene");
                        }

                        s_key.SetActive(true);
                        StartCoroutine(WaitP1Move(KeyCode.S));
                    }
                    break;
                case 21:
                    s_key.SetActive(false);
                    p1_espresso.SetActive(false);
                    TextCanvas1.SetActive(true);
                    StartCoroutine(WaitChangeText1("Finally... a black coffee."));
                    break;
                case 22:
                    TextCanvas1.SetActive(false);
                    p1_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p1_coffee.SetActive(true);
                    c_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP1Move(KeyCode.C));
                    break;
                case 23:
                    minigame1.setKey(KeyCode.C);
                    mini_game1.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame1.enable();
                    }
                    p1_state++;
                    break;
                case 24:
                    //coffee pour sound
                    if (!minigame1.get_state()) {
                        c_key.SetActive(false);
                        p1_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game1.SetActive(false);
                        gale_outcome = minigame1.get_result();

                        if (!gale_outcome) {
                            SceneManager.LoadScene(sceneName: "LoseScene");
                        }
                    }
                    gale_flag = false;
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
    }
}
