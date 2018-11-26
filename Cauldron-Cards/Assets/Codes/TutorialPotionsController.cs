using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPotionsController : MonoBehaviour {

    public GameObject redPotion;
    public GameObject yellowPotion;
    public GameObject greenPotion;
    public GameObject bluePotion;
    GameObject Cat;

    //GameObject character;

    Dictionary<InventoryController.colourNames, GameObject> potion_lookup = new Dictionary<InventoryController.colourNames, GameObject>();

	// Use this for initialization
	void Start () {

        potion_lookup.Add(InventoryController.colourNames.Red, redPotion);
        potion_lookup.Add(InventoryController.colourNames.Yellow, yellowPotion);
        potion_lookup.Add(InventoryController.colourNames.Green, greenPotion);
        potion_lookup.Add(InventoryController.colourNames.Blue, bluePotion);
        Cat = GameObject.Find("Cat_Model");
        //character     = GameObject.Find("Character");
    }
	
	public void makePotion(InventoryController.colourNames colour)
    {
        Instantiate(potion_lookup[colour]);
        Cat.GetComponent<Animator>().SetTrigger("Match");
    }

    public void makePotion(Color colour)
    {
        Cat.GetComponent<Animator>().SetTrigger("Match");
        if (colour == Color.red)
        {
            Instantiate(redPotion);
        }
        else if (colour == Color.yellow)
        {
            Instantiate(yellowPotion);
        }
        else if (colour == Color.green)
        {
            Instantiate(greenPotion);
        }
        else if (colour == Color.blue)
        {
            Instantiate(bluePotion);
        }


    }
}
