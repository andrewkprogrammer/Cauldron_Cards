using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour {

    Canvas pauseCanvas;
    bool pause_enabled;

    void Start()
    {
        pauseCanvas = GameObject.Find("Pause Canvas").GetComponent<Canvas>();
        pause_enabled = false;
    }

    // Update is called once per frame
    void Update () {
        pauseCanvas.enabled = pause_enabled;
	}

    public void pauseUnpause()
    {
        pause_enabled = !pause_enabled;
    }

}
