using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    
    int         redCard_num = 0;
    Text        redCard_Text;

    int         blueCard_num = 0;
    Text        blueCard_Text;

    int         yellowCard_num = 0;
    Text        yellowCard_Text;

    int         orangeCard_num = 0;
    Text        orangeCard_Text;

    int         greenCard_num = 0;
    Text        greenCard_Text;

    //Othercards

    // Use this for initialization
    void Start () {
        redCard_Text = GameObject.Find("redCardText").GetComponent<Text>();

        blueCard_Text = GameObject.Find("blueCardText").GetComponent<Text>();

        yellowCard_Text = GameObject.Find("yellowCardText").GetComponent<Text>();

        orangeCard_Text = GameObject.Find("orangeCardText").GetComponent<Text>();

        greenCard_Text = GameObject.Find("greenCardText").GetComponent<Text>();
    }
    
    public void addARedCard()
    {
        redCard_num++;
        updateCardNumbers();
    }

    public void addABlueCard()
    {
        blueCard_num++;
        updateCardNumbers();
    }

    public void addAYellowCard()
    {
        yellowCard_num++;
        updateCardNumbers();
    }

    public void addAnOrangeCard()
    {
        orangeCard_num++;
        updateCardNumbers();
    }

    public void addAGreenCard()
    {
        greenCard_num++;
        updateCardNumbers();
    }

    public void removeRedCards(int num)
    {
        redCard_num -= num;
        updateCardNumbers();
    }
    public void removeBlueCards(int num)
    {
        blueCard_num -= num;
        updateCardNumbers();
    }

    public void removeYellowCards(int num)
    {
        yellowCard_num -= num;
        updateCardNumbers();
    }

    public void removeOrangeCards(int num)
    {
        orangeCard_num -= num;
        updateCardNumbers();
    }

    public void removeGreenCards(int num)
    {
        greenCard_num -= num;
        updateCardNumbers();
    }

    void updateCardNumbers()
    {
        if (redCard_num < 10)       { redCard_Text.text = "0" + redCard_num.ToString(); }
        else                        { redCard_Text.text = redCard_num.ToString(); }

        if (blueCard_num < 10)      { blueCard_Text.text = "0" + blueCard_num.ToString(); }
        else                        { blueCard_Text.text = blueCard_num.ToString(); }

        if (yellowCard_num < 10)    { yellowCard_Text.text = "0" + yellowCard_num.ToString(); }
        else                        { yellowCard_Text.text = yellowCard_num.ToString(); }

        if (orangeCard_num < 10)    { orangeCard_Text.text = "0" + orangeCard_num.ToString(); }
        else                        { orangeCard_Text.text = orangeCard_num.ToString(); }

        if (greenCard_num < 10)     { greenCard_Text.text = "0" + greenCard_num.ToString(); }
        else                        { greenCard_Text.text = greenCard_num.ToString(); }
    }
}
