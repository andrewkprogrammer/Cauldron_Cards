using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundSetting : MonoBehaviour {

    int value;
    Text display;
    public string audioName;

    MixerControllerBehaviour mixer;

    // Use this for initialization
    void Start () {
        display = GetComponent<Text>();
        value = 10;
        mixer = GameObject.Find("MixerControls").GetComponent<MixerControllerBehaviour>();
	}
	
    public void addOrSubtract(int added)
    {
        if (value + added <= 10 && value + added >= 0)
        {
            value += added;
        }

        mixer.setVolSettings(audioName, value);
        display.text = value.ToString();

    }


}
