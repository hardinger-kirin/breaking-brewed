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

    //p2 assets
    GameObject p2_machine;
    GameObject p2_espresso;
    GameObject p2_coffee;
    GameObject TextCanvas2;
    GameObject ok2;

    GameObject hank;
    GameObject saul;
    GameObject jesse;

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
            switch(p1_state) {

            }
        }

        if(p2_enable) {
            switch(p2_state) {

            }
        }
    }

    private IEnumerator WaitChangeText1(string str) {
        p1_enable = false;
        ok1.SetActive(false);

        for (int i = 0; i < str.Length; i++) {
            p1_currentText = str.Substring(0, i + 1);
            TextCanvas1.GetComponent<TMPro.TextMeshProUGUI>().text = p1_currentText;
            yield return new WaitForSeconds(text_delay);
        }

        ok1.SetActive(true);
        StartCoroutine(WaitGetKey1());
    }

    private IEnumerator WaitGetKey1() {
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.K)));
        p1_enable = true;
        p1_state++;
    }


private IEnumerator WaitChangeText2(string str) {
    p2_enable = false;
    ok2.SetActive(false);

    for (int i = 0; i < str.Length; i++) {
        p2_currentText = str.Substring(0, i + 1);
        TextCanvas2.GetComponent<TMPro.TextMeshProUGUI>().text = p2_currentText;
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

        p2_machine = GameObject.Find("machine2");
        p2_espresso = GameObject.Find("espresso2");
        p2_coffee = GameObject.Find("coffee2");
        TextCanvas2 = GameObject.Find("TextCanvas2");
        ok2 = GameObject.Find("ok2");

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
