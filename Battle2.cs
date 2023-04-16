//Kirin Hardinger
//April 16 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle2 : MonoBehaviour {
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
    int p2_state = 0;
    bool p2_enable = true;
    string p2_currentText = "";
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

    public void set_gus_flag(bool flag) {
        gus_flag = flag;
    }

    public void set_mike_flag(bool flag) {
        mike_flag = flag;
    }

    public int get_p2() {
        return p2_state;
    }

    public void set_gale_flag(bool flag) {
        gale_flag = flag;
    }

    // Update is called once per frame
    void Update() {
        if (gus_flag && p2_enable) {
            switch (p2_state) {
                case 0:
                    minigame2.change_speed(1.7f);
                    TextCanvas2.SetActive(true);
                    StartCoroutine(WaitChangeText2("A plain espresso."));
                    break;
                case 1:
                    TextCanvas2.SetActive(false);
                    p2_espresso.GetComponent<SpriteRenderer>().sprite = empty_espresso;
                    p2_espresso.SetActive(true);
                    u_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP2Move(KeyCode.U));
                    break;
                case 2:
                    minigame2.setKey(KeyCode.U);
                    mini_game2.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame2.enable();
                    }
                    p2_state++;
                    break;
                case 3:
                    //coffee pour sound
                    if (!minigame2.get_state()) {
                        u_key.SetActive(false);
                        p2_espresso.GetComponent<SpriteRenderer>().sprite = full_espresso;
                        mini_game2.SetActive(false);
                        gus_outcome = minigame2.get_result();

                        if (!gus_outcome) {
                            SceneManager.LoadScene(sceneName: "LoseScene");
                        }

                        TextCanvas2.SetActive(true);
                        StartCoroutine(WaitChangeText2("Good. Now a coffee with sugar."));
                    }
                    break;
                case 4:
                    TextCanvas2.SetActive(false);
                    p2_espresso.SetActive(false);
                    p2_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p2_coffee.SetActive(true);
                    n_key.SetActive(true);
                    StartCoroutine(WaitP2Move(KeyCode.N));
                    flag = true;
                    break;
                case 5:
                    mini_game2.SetActive(true);
                    minigame2.setKey(KeyCode.N);
                    if (flag) {
                        flag = false;
                        minigame2.enable();
                    }
                    p2_state++;
                    break;
                case 6:
                    //espresso pour sound
                    if (!minigame2.get_state()) {
                        n_key.SetActive(false);
                        p2_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game2.SetActive(false);
                        gus_outcome = minigame2.get_result();

                        if (!gus_outcome) {
                            SceneManager.LoadScene(sceneName: "LoseScene");
                        }

                        p_key.SetActive(true);
                        StartCoroutine(WaitP2Move(KeyCode.P));
                    }
                    break;
                case 7:
                    p_key.SetActive(false);
                    gus_flag = false;
                    p2_state++;
                    break;
                default:
                    break;
            }
        }
        else if (mike_flag && p2_enable) {
            switch (p2_state) {
                case 8:
                    minigame2.change_speed(1f);
                    TextCanvas2.SetActive(true);
                    StartCoroutine(WaitChangeText2("A black coffee."));
                    break;
                case 9:
                    TextCanvas2.SetActive(false);
                    p2_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p2_coffee.SetActive(true);
                    n_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP2Move(KeyCode.N));
                    break;
                case 10:
                    minigame2.setKey(KeyCode.N);
                    mini_game2.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame2.enable();
                    }
                    p2_state++;
                    break;
                case 11:
                    //coffee pour sound
                    if (!minigame2.get_state()) {
                        n_key.SetActive(false);
                        p2_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game2.SetActive(false);
                        mike_outcome = minigame2.get_result();
                    }
                    mike_flag = false;
                    p2_state++;
                    break;
            }
        }
        else if (gale_flag && p2_enable) {
            switch (p2_state) {
                case 12:
                    minigame2.change_speed(1.7f);
                    TextCanvas2.SetActive(true);
                    StartCoroutine(WaitChangeText2("A coffee with cream and sugar."));
                    break;
                case 13:
                    TextCanvas2.SetActive(false);
                    p2_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p2_coffee.SetActive(true);
                    n_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP2Move(KeyCode.N));
                    break;
                case 14:
                    minigame2.setKey(KeyCode.N);
                    mini_game2.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame2.enable();
                    }
                    p2_state++;
                    break;
                case 15:
                    //coffee pour sound
                    if (!minigame2.get_state()) {
                        n_key.SetActive(false);
                        p2_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game2.SetActive(false);
                        gale_outcome = minigame2.get_result();

                        if (!gale_outcome) {
                            SceneManager.LoadScene(sceneName: "LoseScene");
                        }

                        o_key.SetActive(true);
                        StartCoroutine(WaitP2Move(KeyCode.O));
                    }
                    break;
                case 16:
                    o_key.SetActive(false);
                    p_key.SetActive(true);
                    StartCoroutine(WaitP2Move(KeyCode.P));
                    break;
                case 17:
                    p_key.SetActive(false);
                    p2_coffee.SetActive(false);
                    TextCanvas2.SetActive(true);
                    StartCoroutine(WaitChangeText2("An espresso with sugar."));
                    break;
                case 18:
                    TextCanvas2.SetActive(false);
                    p2_espresso.GetComponent<SpriteRenderer>().sprite = empty_espresso;
                    p2_espresso.SetActive(true);
                    u_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP2Move(KeyCode.U));
                    break;
                case 19:
                    minigame2.setKey(KeyCode.U);
                    mini_game2.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame2.enable();
                    }
                    p2_state++;
                    break;
                case 20:
                    //coffee pour sound
                    if (!minigame2.get_state()) {
                        u_key.SetActive(false);
                        p2_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game2.SetActive(false);
                        gale_outcome = minigame2.get_result();

                        if (!gale_outcome) {
                            SceneManager.LoadScene(sceneName: "LoseScene");
                        }

                        p_key.SetActive(true);
                        StartCoroutine(WaitP2Move(KeyCode.P));
                    }
                    break;
                case 21:
                    p_key.SetActive(false);
                    p2_espresso.SetActive(false);
                    TextCanvas2.SetActive(true);
                    StartCoroutine(WaitChangeText2("Finally... a black coffee."));
                    break;
                case 22:
                    TextCanvas2.SetActive(false);
                    p2_coffee.GetComponent<SpriteRenderer>().sprite = empty_coffee;
                    p2_coffee.SetActive(true);
                    n_key.SetActive(true);
                    flag = true;
                    StartCoroutine(WaitP2Move(KeyCode.N));
                    break;
                case 23:
                    minigame2.setKey(KeyCode.N);
                    mini_game2.SetActive(true);
                    if (flag) {
                        flag = false;
                        minigame2.enable();
                    }
                    p2_state++;
                    break;
                case 24:
                    //coffee pour sound
                    if (!minigame2.get_state()) {
                        n_key.SetActive(false);
                        p2_coffee.GetComponent<SpriteRenderer>().sprite = full_coffee;
                        mini_game2.SetActive(false);
                        gale_outcome = minigame2.get_result();

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
    }
}
