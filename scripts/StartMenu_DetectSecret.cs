using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu_DetectSecret : MonoBehaviour
{
    //Found from https://answers.unity.com/questions/1146027/c-make-something-happen-if-i-press-a-sequence-of-k.html
    private KeyCode[] sequence = new KeyCode[] {KeyCode.C, KeyCode.A, KeyCode.T};
    private int sequenceCounter;
    void Start()
    {
     sequenceCounter = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(sequence[sequenceCounter])){
            sequenceCounter++;
            if(sequenceCounter == sequence.Length){
                Debug.Log("Cat girls have arrived");
                sequenceCounter = 0;
            }
        }
        else if (Input.anyKeyDown){
            sequenceCounter = 0;
        }
    }
}
