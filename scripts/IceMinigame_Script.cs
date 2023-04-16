using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMinigame_Script : MonoBehaviour
{

    private bool waitingForUserInput = true;
    private Collider2D collisionObject;
    private Collider2D collisionSubject;
    
        GameObject collisionLine;
    void Start(){
        collisionObject = GameObject.Find("CollisionLine").GetComponent<Collider2D>();
        collisionSubject = GameObject.Find("GoalMarker").GetComponent<Collider2D>();
        collisionLine = GameObject.Find("CollisionLine");
    }
    void Update(){
        if(!waitingForUserInput){

            if(collisionObject.IsTouching(collisionSubject)){
                if(Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.I)){
                    Debug.Log("Game Pass");
                    //Game win condition
                    this.enabled = false;
                }
            }
            else if (Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.I)){
                Debug.Log("Too Early");
                //This means failure, below line stops the script early so instead have it
                // do the game over screen or whatever
                this.enabled = false;

            }
            if(Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.F)){
                transform.localScale += new Vector3(0, .01f, 0);
                transform.Translate(Vector2.up * 0.005f);
                collisionLine.transform.Translate(Vector2.up * 0.01f);
            }
        }
        else{
            if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.F)){
                waitingForUserInput = false;
            }
        }
    }

}
