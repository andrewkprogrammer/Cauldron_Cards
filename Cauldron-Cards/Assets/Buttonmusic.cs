using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonmusic : MonoBehaviour {

    GameObject musicControls;
    SceneLoaderBehaviour sceneLoader;

    public string nextSceneName;

    void Start()
    {
        musicControls = GameObject.Find("Menu Music Emitter");
        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoaderBehaviour>();
    }

    private void Update()
    {
        if (musicControls == null)
        {
            sceneLoader.loadScene(nextSceneName);
        }
    }

    public void turnOff()
    {
        musicControls.SendMessage("turnOff");
    }
}
