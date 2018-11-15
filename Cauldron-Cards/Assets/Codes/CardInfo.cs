using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardInfo : MonoBehaviour
{
    
    public enum CardColour
    {
        red, blue, green, yellow
    }
    CardColour selectedColour;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColour(CardColour colour)
    {
        selectedColour = colour;
    }


}
