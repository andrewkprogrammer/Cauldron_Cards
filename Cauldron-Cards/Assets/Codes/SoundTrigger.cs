using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

    FMODUnity.StudioEventEmitter emitter;

    // Use this for initialization
    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
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
}
