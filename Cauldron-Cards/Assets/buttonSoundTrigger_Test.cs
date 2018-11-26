using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSoundTrigger_Test : MonoBehaviour {

    FMODUnity.StudioEventEmitter emitter;

	// Use this for initialization
	void Start () {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
	}
	
	// Update is called once per frame
	public void playSound()
    {
        emitter.Play();
    }
}
