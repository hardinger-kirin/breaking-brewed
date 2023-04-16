using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class and_nick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(move_on());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator move_on() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName: "StartMenuScene");
    }
}
