using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTick : MonoBehaviour {

    GameObject elapsedTurnsBar;

    public int Turns_Total;
    public int Turns_Elapsed;

	// Use this for initialization
	void Start () {
        elapsedTurnsBar = GameObject.Find("Turn_Bar_Elapsed");
	}
	
	// Update is called once per frame
	void Update () {
        RectTransform elapsed_Transform = elapsedTurnsBar.GetComponent<RectTransform>();
        float barwidth = 100 - (Turns_Elapsed / Turns_Total);
	}
}
