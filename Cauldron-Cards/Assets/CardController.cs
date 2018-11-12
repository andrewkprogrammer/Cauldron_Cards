using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour {

    GameObject  redCard;
    int         redCard_num = 0;
    Text        redCard_Text;

    GameObject blueCard;
    int blueCard_num = 0;
    Text blueCard_Text;

    //Othercards

    // Use this for initialization
    void Start () {
        redCard = GameObject.Find("RedCards");
        redCard_Text = GameObject.Find("redCardText").GetComponent<Text>();

        blueCard = GameObject.Find("BlueCards");
        blueCard_Text = GameObject.Find("blueCardText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
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

    public void removeRedcards(int num)
    {
        redCard_num -= num;
        updateCardNumbers();
    }
    public void removeBluecards(int num)
    {
        blueCard_num -= num;
        updateCardNumbers();
    }

    void updateCardNumbers()
    {
        if (redCard_num < 10)   { redCard_Text.text = "0" + redCard_num.ToString(); }
        else                    { redCard_Text.text = redCard_num.ToString(); }

        if (blueCard_num < 10) { blueCard_Text.text = "0" + blueCard_num.ToString(); }
        else { blueCard_Text.text = blueCard_num.ToString(); }

    }
}
