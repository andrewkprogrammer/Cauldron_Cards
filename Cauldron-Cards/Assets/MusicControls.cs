using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControls : MonoBehaviour {

    SoundTrigger emitter;
    public float fadeOutTime;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        emitter = GetComponent<SoundTrigger>();
	}

    void Update()
    {
         if (emitter.FadedOutComplete == true)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void turnOff () {
        emitter.fadeOutVolume(fadeOutTime);
	}
}
