using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPotionsController : MonoBehaviour {

    GameObject redPotion;
    GameObject yellowPotion;
    GameObject greenPotion;
    GameObject bluePotion;

    //GameObject character;

    Dictionary<InventoryController.colourNames, GameObject> potion_lookup = new Dictionary<InventoryController.colourNames, GameObject>();

	// Use this for initialization
	void Start () {
        redPotion       = GameObject.Find("RedPotion");
        yellowPotion    = GameObject.Find("YellowPotion");
        greenPotion     = GameObject.Find("GreenPotion");
        bluePotion      = GameObject.Find("BluePotion");

        potion_lookup.Add(InventoryController.colourNames.Red, redPotion);
        potion_lookup.Add(InventoryController.colourNames.Yellow, yellowPotion);
        potion_lookup.Add(InventoryController.colourNames.Green, greenPotion);
        potion_lookup.Add(InventoryController.colourNames.Blue, bluePotion);

        //character     = GameObject.Find("Character");
    }
	
	public void makePotion(InventoryController.colourNames colour)
    {
        potion_lookup[colour].GetComponent<PotionMaker>().makePotion();

    }
}
