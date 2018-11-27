using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwap : MonoBehaviour {

    public Canvas canvas_start;
    bool cnvStart_enabled;

    public Canvas canvas_end;
    bool cnvEnd_enabled;

    // Use this for initialization
    void Start () {
        cnvStart_enabled = true;
        cnvEnd_enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        canvas_start.enabled = cnvStart_enabled;
        canvas_end.enabled = cnvEnd_enabled;
	}

    public void swapCanvas()
    {
        cnvEnd_enabled = !cnvEnd_enabled;
        cnvStart_enabled = !cnvStart_enabled;
    }
}
