using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTransitionTrigger : MonoBehaviour {

    FMODUnity.StudioEventEmitter emitter;
    MixerControllerBehaviour mixer;


    bool fadingIn;
    bool fadingOut;

    float time_elapsed;

    float transitionTime = 1.0f;
    public float fadeInTime;
    float fadeOutTime;

    bool FadedInComplete = false;
    [HideInInspector]
    public bool FadedOutComplete = false;

    public string audioName;
    CanvasGroup BlackPanel;

    SceneLoaderBehaviour sceneLoader;
    public string nextSceneName;

    public bool fadeInStart;



// Use this for initialization
void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        mixer = GameObject.Find("MixerControls").GetComponent<MixerControllerBehaviour>();
        BlackPanel = GameObject.Find("BlackFadePanel").GetComponent<CanvasGroup>();
        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoaderBehaviour>();
        if (fadeInStart) { fadeInVolume(fadeInTime); }
    }

    void Update()
    {
        if (fadingIn || fadingOut)
        {
            time_elapsed += Time.deltaTime;

            float percent = time_elapsed / transitionTime;

           if (fadingOut)
            {
                percent = 1.0f - percent;
            }

            mixer.setVolSettings(audioName, percent);
            BlackPanel.alpha = 1.0f - percent;

            if (fadingIn && percent >= 1.0f)
            {
                fadingIn = false;
                

            }
            else if (fadingOut && percent <= 0.0f)
            {
                fadingOut = false;
                sceneLoader.loadScene(nextSceneName);
            }

        }
      
    }

    // Update is called once per frame
    public void playSound()
    {
        emitter.Play();
    }

    public void setParameter(string name, float amount)
    {
        emitter.SetParameter(name, amount);
    }

    public void fadeInVolume(float time)
    { 
        time_elapsed = 0.0f;
        fadeInTime = time;
        transitionTime = fadeInTime;
        fadingIn = true;
    }

    public void fadeOutVolume(float time)
    {

        time_elapsed = 0.0f;
        fadeOutTime = time;
        transitionTime = fadeOutTime;
        fadingOut = true;
    }

    public void setNextSceneName(string name)
    {
        nextSceneName = name;
    }
}
