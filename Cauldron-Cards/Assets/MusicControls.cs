using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControls : MonoBehaviour {

    SoundTransitionTrigger emitter;
    public float fadeOutTime;

    public string nextSceneName;

    SceneLoaderBehaviour sceneLoader;

	// Use this for initialization
	void Start () {
        emitter = GetComponent<SoundTransitionTrigger>();
        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoaderBehaviour>();
	}


    // Update is called once per frame
    public void turnOff () {
        emitter.setNextSceneName(nextSceneName);
        emitter.fadeOutVolume(fadeOutTime);
	}
    public void turnOff(string sceneName)
    {
        emitter.setNextSceneName(sceneName);
        emitter.fadeOutVolume(fadeOutTime);
    }
}
