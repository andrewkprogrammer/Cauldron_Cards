using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

    FMODUnity.StudioEventEmitter emitter;
    float start_value;
    float end_value;

    bool fadingIn;
    bool fadingOut;

    float time_elapsed;
    float percent;

    float transitionTime = 1.0f;
    float fadeInTime;
    float fadeOutTime;

    bool FadedInComplete = false;
    [HideInInspector]
    public bool FadedOutComplete = false;

    // Use this for initialization
    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    void Update()
    {
        if (fadingIn || fadingOut)
        {
            if (fadingIn)
            {
                transitionTime = fadeInTime;
            }
            else if (fadingOut)
            {
                transitionTime = fadeOutTime;
            }

            time_elapsed += Time.deltaTime;
          
            if (fadingIn)
            {
                float percent = time_elapsed / transitionTime;
            }
            else if (fadingOut)
            {
                float percent = 1.0f - (time_elapsed / transitionTime);
            }

            setParameter("Volume", percent);

            if (fadingIn && percent <= 0.0f)
            {
                fadingIn = false;
                FadedInComplete = true;
            }
            else if (fadingOut && percent >= 1.0f)
            {
                fadingOut = false;
                FadedOutComplete = true;
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
        start_value = 0.0f;
        end_value = 1.0f;
        time_elapsed = 0.0f;
        fadeInTime = time;
        fadingIn = true;
    }

    public void fadeOutVolume(float time)
    {
        start_value = 1.0f;
        end_value = 0.0f;
        time_elapsed = 0.0f;
        fadeOutTime = time;
        fadingOut = true;
    }
}
