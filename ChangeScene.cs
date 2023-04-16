using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    string sceneName = "FadeScene2";
    SceneFading Fade;
    // Start is called before the first frame update
    void Start()
    {
        Fade = FindObjectOfType<SceneFading>();
        StartCoroutine(sceneChange());
    }

    // Update is called once per frame
    public IEnumerator sceneChange(){
        Fade.setFadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
    
}
