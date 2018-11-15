using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour {


    Dictionary<InventoryController.colourNames, PotionInfo> potion_data = new Dictionary<InventoryController.colourNames, PotionInfo>();

    PotionInfo red_data;
    PotionInfo yellow_data;
    PotionInfo green_data;
    PotionInfo blue_data;

    InventoryController inventory;

    // Use this for initialization
    void Start () {

        red_data = GameObject.Find("RedPotion").GetComponent<PotionInfo>();
        yellow_data = GameObject.Find("YellowPotion").GetComponent<PotionInfo>();
        green_data = GameObject.Find("GreenPotion").GetComponent<PotionInfo>();
        blue_data = GameObject.Find("BluePotion").GetComponent<PotionInfo>();


        potion_data.Add(InventoryController.colourNames.Red, red_data);
        potion_data.Add(InventoryController.colourNames.Yellow, yellow_data);
        potion_data.Add(InventoryController.colourNames.Green, green_data);
        potion_data.Add(InventoryController.colourNames.Blue, blue_data);

        inventory = GameObject.Find("InventoryController").GetComponent<InventoryController>();
	}
	
    public void makePotion (InventoryController.colourNames colour)
    {
        if (!checkRequirements(colour))
        {
            //Potion making failed!
        }
        else
        {
            PotionInfo colour_reqs = potion_data[colour];
            foreach (InventoryController.colourNames shade in Enum.GetValues(typeof(InventoryController.colourNames)))
            {
                int required = colour_reqs.getRequiredValue(shade);
                inventory.removeCards(shade, required);
            }
            //Create Potion
        }
    }

	public bool checkRequirements(InventoryController.colourNames colour)
    {
        PotionInfo colour_reqs = potion_data[colour];
        bool meetsRequirements = true;
        foreach (InventoryController.colourNames shade in Enum.GetValues(typeof(InventoryController.colourNames)))
        {
            int required = colour_reqs.getRequiredValue(shade);
            int holding = inventory.getColourValue(shade);
            if (holding < required) { meetsRequirements = false; continue; }
        }
        return meetsRequirements;
    }
}
