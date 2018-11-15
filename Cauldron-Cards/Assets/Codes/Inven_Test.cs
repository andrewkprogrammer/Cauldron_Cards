using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven_Test : MonoBehaviour {

    InventoryController Inven_controls;

    void Start()
    {
        Inven_controls = GameObject.Find("InventoryController").GetComponent<InventoryController>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            Inven_controls.addACard(InventoryController.colourNames.Red);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Inven_controls.addACard(InventoryController.colourNames.Blue);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Inven_controls.addACard(InventoryController.colourNames.Yellow);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Inven_controls.addACard(InventoryController.colourNames.Orange);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Inven_controls.addACard(InventoryController.colourNames.Green);
        }

    }
}
