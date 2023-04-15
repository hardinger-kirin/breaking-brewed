//Nick Larson
//April 15 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{

    //Controls how fast the text appears
    public float textDelay = 0.4f;
    public string fullText;
    private string currentText = "";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    //Type Writer Function is ShowText
    // This is coded for the use of TextMeshPro text objects inside a canvas UI element(?), not sure what the right name for that is
    // If it doesn't work, try and change the type "TMPro.TextMeshProUGUI" to "TMPro.TextMeshPro"
    // Created by following: https://youtu.be/1qbjmb_1hV4
    IEnumerator ShowText(){
        for(int i = 0; i < fullText.Length; i++){
            currentText = fullText.Substring(0, i+1);
            this.GetComponent<TMPro.TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
    }
}