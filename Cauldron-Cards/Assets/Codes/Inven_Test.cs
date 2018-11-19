using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven_Test : MonoBehaviour {

    InventoryController Inven_controls;

    //PotionController Potion_controls;
    TutorialPotionsController Tut_Potion_controls;

    TurnTick turnTick;

    void Start()
    {
        //Potion_controls = GameObject.Find("PotionController").GetComponent<PotionController>();
        Tut_Potion_controls = GameObject.Find("TutorialPotionController").GetComponent<TutorialPotionsController>();
        turnTick = GameObject.Find("Turn-Ticker").GetComponent<TurnTick>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            Tut_Potion_controls.makePotion(InventoryController.colourNames.Red);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Tut_Potion_controls.makePotion(InventoryController.colourNames.Blue);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Tut_Potion_controls.makePotion(InventoryController.colourNames.Yellow);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Tut_Potion_controls.makePotion(InventoryController.colourNames.Green);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            turnTick.onTurnTick();
        }

    }
}
