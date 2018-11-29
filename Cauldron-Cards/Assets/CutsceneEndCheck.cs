using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneEndCheck : MonoBehaviour {

    VideoPlayer cutscene;

    SceneLoaderBehaviour sceneLoader;
    public string nextSceneName;

    float time = 0;

    private void Start()
    {
        cutscene = GameObject.Find("CutSceneVideo").GetComponent<VideoPlayer>();
        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoaderBehaviour>();
    }

    private void LateUpdate()
    {
        time += Time.deltaTime;
        if (time > 1.0f && !cutscene.isPlaying)
        {
            sceneLoader.loadScene(nextSceneName);
        }
    }

}
