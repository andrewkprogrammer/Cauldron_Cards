using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven_Test : MonoBehaviour {

    CardController CardControls;

    void Start()
    {
        CardControls = GameObject.Find("CardController").GetComponent<CardController>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            CardControls.addARedCard();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            CardControls.addABlueCard();
        }
    }
}
