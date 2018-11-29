using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwap : MonoBehaviour {

    public Canvas canvas_start;

    public Canvas canvas_second;

    public Canvas canvas_third;

    bool[] enabledList = new bool[3] { true, false, false };

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        canvas_start.enabled    = enabledList[0];
        canvas_second.enabled   = enabledList[1];
        canvas_third.enabled    = enabledList[2];
	}

    public void swapToCanvas(int num)
    {
        for (int i = 0; i < enabledList.Length; ++i)
        {
            if (i == num)
            {
                enabledList[i] = true;
            }
            else
            {
                enabledList[i] = false;
            }
        }
    }
}
