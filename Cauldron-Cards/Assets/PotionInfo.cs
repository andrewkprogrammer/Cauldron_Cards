using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInfo : MonoBehaviour {

    [Range(0,6)]
    public int redRequired;

    [Range(0, 6)]
    public int orangeRequired;

    [Range(0, 6)]
    public int yellowRequired;

    [Range(0, 6)]
    public int greenRequired;

    [Range(0, 6)]
    public int blueRequired;

    public bool inflictsPoison;
    public bool inflictsFreeze;

    public int getRequiredValue (InventoryController.colourNames colour)
    {
        if (colour == InventoryController.colourNames.Red)
        {
            return redRequired;
        }
        else if (colour == InventoryController.colourNames.Orange)
        {
            return orangeRequired;
        }
        else if (colour == InventoryController.colourNames.Yellow)
        {
            return yellowRequired;
        }
        else if (colour == InventoryController.colourNames.Green)
        {
            return greenRequired;
        }
        else if (colour == InventoryController.colourNames.Blue)
        {
            return blueRequired;
        }
        else
        { return 0; }
    }



};
