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

    Dictionary<colourNames, int> Inven_Values = new Dictionary<colourNames, int>()
    {
        {colourNames.Red, 0},
        {colourNames.Orange, 0},
        {colourNames.Yellow, 0},
        {colourNames.Green, 0},
        {colourNames.Blue, 0}
    }
    ;

    Text        redCard_Text;

    int         blueCard_num = 0;
    Text        blueCard_Text;

    int         yellowCard_num = 0;
    Text        yellowCard_Text;

    int         orangeCard_num = 0;
    Text        orangeCard_Text;

    int         greenCard_num = 0;
    Text        greenCard_Text;

    TurnTick    turnTick_funcs; 

    //Othercards

    // Use this for initialization
    void Start () {

        redCard_Text = GameObject.Find("redCardText").GetComponent<Text>();

        blueCard_Text = GameObject.Find("blueCardText").GetComponent<Text>();

        yellowCard_Text = GameObject.Find("yellowCardText").GetComponent<Text>();

        orangeCard_Text = GameObject.Find("orangeCardText").GetComponent<Text>();

        greenCard_Text = GameObject.Find("greenCardText").GetComponent<Text>();

        turnTick_funcs = GameObject.Find("Turn-Ticker").GetComponent<TurnTick>();
    }
    
    public void addACard(colourNames colour)
    {
        Inven_Values[colour] += 1;
        updateCardNumbers();
        turnTick_funcs.onTurnTick();
    }

    public void addARedCard()
    {
        Inven_Values[colourNames.Red] += 1;
        updateCardNumbers();
        turnTick_funcs.onTurnTick();
    }

    public void addABlueCard()
    {
        blueCard_num++;
        updateCardNumbers();
        turnTick_funcs.onTurnTick();
    }

    public void addAYellowCard()
    {
        yellowCard_num++;
        updateCardNumbers();
        turnTick_funcs.onTurnTick();
    }

    public void addAnOrangeCard()
    {
        orangeCard_num++;
        updateCardNumbers();
        turnTick_funcs.onTurnTick();
    }

    public void addAGreenCard()
    {
        greenCard_num++;
        updateCardNumbers();
        turnTick_funcs.onTurnTick();
    }

    public void removeCards(colourNames colour, int num)
    {
        Inven_Values[colour] -= num;
        updateCardNumbers();
    }

    void updateCardNumbers()
    {
        if (Inven_Values[colourNames.Red] < 10)         { redCard_Text.text = "0" + Inven_Values[colourNames.Red].ToString(); }
        else                                            { redCard_Text.text = Inven_Values[colourNames.Red].ToString(); }

        if (Inven_Values[colourNames.Blue] < 10)        { blueCard_Text.text = "0" + Inven_Values[colourNames.Blue].ToString(); }
        else                                            { blueCard_Text.text = Inven_Values[colourNames.Blue].ToString(); }

        if (Inven_Values[colourNames.Yellow] < 10)      { yellowCard_Text.text = "0" + Inven_Values[colourNames.Yellow].ToString(); }
        else                                            { yellowCard_Text.text = Inven_Values[colourNames.Yellow].ToString(); }

        if (Inven_Values[colourNames.Orange] < 10)      { orangeCard_Text.text = "0" + Inven_Values[colourNames.Orange].ToString(); }
        else                                            { orangeCard_Text.text = Inven_Values[colourNames.Orange].ToString(); }

        if (Inven_Values[colourNames.Green] < 10)       { greenCard_Text.text = "0" + Inven_Values[colourNames.Green].ToString(); }
        else                                            { greenCard_Text.text = Inven_Values[colourNames.Green].ToString(); }
    }
}
