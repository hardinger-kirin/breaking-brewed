//Nick Larson
//April 15 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeEvent_SliderMovement : MonoBehaviour
{
    GameObject cursor;

    float moveSpeed = 6f;
    float currentX;

    //Values to keep track of the "critical" area and size
    int quickTimeAreaCenter = 965;
    int quickTimeAreaScale = 260;

    int quickTimeAreaLB, quickTimeAreaRB;

    KeyCode targetKey = KeyCode.C;

    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.Find("QuickTime_Cursor");
        quickTimeAreaRB = (quickTimeAreaCenter + 15) + (quickTimeAreaScale/2);
        quickTimeAreaLB = (quickTimeAreaCenter - 15) - (quickTimeAreaScale/2); 
    }

    void setKey(KeyCode keyPress){
        targetKey = keyPress;
    }

    // Update is called once per frame
    void Update()
    {   
        currentX = cursor.transform.position.x;
        //Check to see if they did the quick time event
        if (Input.GetKeyDown(targetKey)){
            if (currentX > quickTimeAreaLB && currentX < quickTimeAreaRB){
                Debug.Log("Successful QuickTime!");
            }
            else {
                Debug.Log("QuickTime Fail!");
            }
        }
        else {
            //If the user didn't do the quick time, continue to move the cursor 
            if (currentX > (960 + (1500/2))){
                moveSpeed *= -1;
            }
            else if (currentX < (960 - (1500/2))){
                moveSpeed *= -1;
            }

            }
            transform.Translate(Vector2.right *moveSpeed);
        
    }
}
