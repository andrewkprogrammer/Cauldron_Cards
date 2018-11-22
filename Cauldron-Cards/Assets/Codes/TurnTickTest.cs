using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTickTest : MonoBehaviour {

    public GameObject Ticker;
    TurnTick TickScript;

    void Start()
    {
        TickScript = Ticker.GetComponent<TurnTick>();    
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            TickScript.onTurnTick();
        }
	}
}
