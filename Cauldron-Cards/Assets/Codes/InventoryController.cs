using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public enum colourNames
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue
    }

    public class inven_Value
    {
        public inven_Value(Text display) { text = display; number = 0; }
        public int number;
        public Text text;
    }

    Text        redCard_Text;
    Text        blueCard_Text;
    Text        yellowCard_Text;
    Text        orangeCard_Text;
    Text        greenCard_Text;

    public Dictionary<colourNames, inven_Value> Inven_Lookup = new Dictionary<colourNames, inven_Value>();



    TurnTick    turnTick_funcs; 

    //Othercards

    // Use this for initialization
    void Start () {

        turnTick_funcs = GameObject.Find("Turn-Ticker").GetComponent<TurnTick>();

        redCard_Text = GameObject.Find("redCardText").GetComponent<Text>();
        blueCard_Text = GameObject.Find("blueCardText").GetComponent<Text>();
        yellowCard_Text = GameObject.Find("yellowCardText").GetComponent<Text>();
        orangeCard_Text = GameObject.Find("orangeCardText").GetComponent<Text>();
        greenCard_Text = GameObject.Find("greenCardText").GetComponent<Text>();

        Inven_Lookup[colourNames.Red] = new inven_Value(redCard_Text);
        Inven_Lookup[colourNames.Orange] = new inven_Value(orangeCard_Text);
        Inven_Lookup[colourNames.Yellow] = new inven_Value(yellowCard_Text);
        Inven_Lookup[colourNames.Green] = new inven_Value(greenCard_Text);
        Inven_Lookup[colourNames.Blue] = new inven_Value(blueCard_Text);

    }
    
    public void addACard(colourNames colour)
    {
        Inven_Lookup[colour].number += 1;
        updateCardNumbers();
        turnTick_funcs.onTurnTick();
    }

    public void removeCards(colourNames colour, int num)
    {
        Inven_Lookup[colour].number -= num;
        updateCardNumbers();
    }

    void updateCardNumbers()
    {
        foreach (var entry in Inven_Lookup)
        {
            int value = entry.Value.number;
            Text write = entry.Value.text;

            string displayText;
            if (value < 10) { displayText = "0" + value.ToString(); }
            else { displayText = value.ToString(); }

            write.text = displayText;
        }
    }

    public int getColourValue(colourNames colour)
    {
        return Inven_Lookup[colour].number;
    }
}
