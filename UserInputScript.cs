//Nick Larson
//April 15 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.J)){
            Debug.Log("Switch Left");
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.L)){
            Debug.Log("Switch Right");
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K)){
            Debug.Log("Submit Order");
        }
        else if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.I)){
            Debug.Log("Ice");
        }
        else if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.N)){
            Debug.Log("Coffee");
        }
        else if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.U)){
            Debug.Log("Espresso");
        }
        else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.O)){
            Debug.Log("Milk");
        }
        else if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.P)){
            Debug.Log("Sugar");
        }
    }
}