using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour {

    GameObject SceneLoader;

    void Start()
    {
        SceneLoader = GameObject.Find("SceneLoader");
    }

    public void buttonPress (string nextScene)
    {
        SceneLoader.SendMessage("loadScene", nextScene);
    }
}
