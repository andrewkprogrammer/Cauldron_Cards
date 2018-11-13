using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven_Test : MonoBehaviour {

    InventoryController CardControls;

    void Start()
    {
        CardControls = GameObject.Find("CardController").GetComponent<InventoryController>();
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

        if (Input.GetKeyDown(KeyCode.Y))
        {
            CardControls.addAYellowCard();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            CardControls.addAnOrangeCard();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            CardControls.addAGreenCard();
        }
    }
}
