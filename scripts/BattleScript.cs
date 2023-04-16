//Kirin Hardinger
//April 16 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScript : MonoBehaviour {
    GameObject TextCanvas1;
    GameObject TextCanvas2;
    GameObject TextCanvas3;
    GameObject ok1;
    GameObject ok2;
    GameObject ok3;
    GameObject text1;
    GameObject text2;
    GameObject text3;
    string currentText1 = "";
    string currentText2 = "";
    string currentText3 = "";
    private float text_delay = 0.05f;

    GameObject mike;
    GameObject gus;
    GameObject gale;

    Battle1 battle_1;
    Battle2 battle_2;

    bool enable = true;
    int state = 0;

    // Start is called before the first frame update
    void Start() {
        battle_1 = FindObjectOfType<Battle1>();
        battle_2 = FindObjectOfType<Battle2>();

        mike = GameObject.Find("mike");
        gus = GameObject.Find("gus");
        gale = GameObject.Find("gale");
        TextCanvas3 = GameObject.Find("TextCanvas3");
        ok3 = GameObject.Find("ok3");
        text3 = GameObject.Find("text3");

        mike.SetActive(false);
        gus.SetActive(false);
        gale.SetActive(false);
        TextCanvas3.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if(enable && battle_1.get_p1() < 8 && battle_2.get_p2() < 8) {
            switch(state) {
                case 0:
                    gus.SetActive(true);
                    TextCanvas3.SetActive(true);
                    StartCoroutine(WaitChangeText3("Well well well."));
                    break;
                case 1:
                    StartCoroutine(WaitChangeText3("Looks like you two survived that."));
                    break;
                case 2:
                    StartCoroutine(WaitChangeText3("...but can you survive me?"));
                    break;
                case 3:
                    TextCanvas3.SetActive(false);
                    battle_1.set_gus_flag(true);
                    battle_2.set_gus_flag(true);
                    break;
                default:
                    break;
            }
        } else if(enable && battle_1.get_p1() == 8 && battle_2.get_p2() == 8) {
            switch(state) {
                case 3:
                    TextCanvas3.SetActive(true);
                    StartCoroutine(WaitChangeText3("I am a man of honor. I can admit when I am defeated."));
                    break;
                case 4:
                    StartCoroutine(WaitChangeText3("But I must warn you..."));
                    break;
                case 5:
                    StartCoroutine(WaitChangeText3("That was child's play in comparison to the owner."));
                    break;
                case 6:
                    gus.SetActive(false);
                    mike.SetActive(true);
                    StartCoroutine(WaitChangeText3("Hey, kids."));
                    break;
                case 7:
                    StartCoroutine(WaitChangeText3("Thought I'd stop by. I've heard a lot about you two."));
                    break;
                case 8:
                    StartCoroutine(WaitChangeText3("Good and (Breaking) bad."));
                    break;
                case 9:
                    StartCoroutine(WaitChangeText3("Well anyway. Make me and my granddaughter something good."));
                    break;
                case 10:
                    TextCanvas3.SetActive(false);
                    battle_1.set_mike_flag(true);
                    battle_2.set_mike_flag(true);
                    break;
                default:
                    break;
            }
        } else if(enable && battle_1.get_p1() == 12 && battle_2.get_p2() == 12) {
            switch(state) {
                case 10:
                    TextCanvas3.SetActive(true);
                    StartCoroutine(WaitChangeText3("What, did you think my order was gonna be difficult?"));
                    break;
                case 11:
                    StartCoroutine(WaitChangeText3("This is the calm before the storm."));
                    break;
                case 12:
                    mike.SetActive(false);
                    gale.SetActive(true);
                    StartCoroutine(WaitChangeText3("Well, if it isn't Walter White..."));
                    break;
                case 13:
                    StartCoroutine(WaitChangeText3("And his trusty partner who replaced me."));
                    break;
                case 14:
                    StartCoroutine(WaitChangeText3("Me. Gale fucking Boetticher."));
                    break;
                case 15:
                    StartCoroutine(WaitChangeText3("You want my forgiveness?"));
                    break;
                case 16:
                    StartCoroutine(WaitChangeText3("Work for it."));
                    break;
                case 17:
                    StartCoroutine(WaitChangeText3("Best me in everything I love."));
                    break;
                case 19:
                    StartCoroutine(WaitChangeText3("Cooking..."));
                    break;
                case 20:
                    StartCoroutine(WaitChangeText3("Brewing..."));
                    break;
                case 21:
                    StartCoroutine(WaitChangeText3("End it already."));
                    TextCanvas3.SetActive(false);
                    battle_1.set_gale_flag(true);
                    battle_2.set_gale_flag(true);
                    break;
                default:
                    break;
            }
        } else if(battle_1.get_p1() == 24 && battle_2.get_p2() == 24) {
            SceneManager.LoadScene(sceneName: "WinScene");
        }
    }

    private IEnumerator WaitChangeText3(string str) {
        enable = false;
        ok3.SetActive(false);

        for (int i = 0; i < str.Length; i++) {
            currentText3 = str.Substring(0, i + 1);
            text3.GetComponent<TMPro.TextMeshProUGUI>().text = currentText3;
            yield return new WaitForSeconds(text_delay);
        }

        ok3.SetActive(true);
        StartCoroutine(WaitGetKey3());
    }

    private IEnumerator WaitGetKey3() {
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.K)));
        enable = true;
        state++;
    }

    private IEnumerator WaitP3Move(KeyCode expected) {
        enable = false;
        yield return new WaitUntil(() => Input.GetKeyDown(expected));
        enable = true;
        state++;
    }
}
