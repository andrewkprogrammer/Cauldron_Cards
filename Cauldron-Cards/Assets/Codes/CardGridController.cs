using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGridController : MonoBehaviour {

    //public bool cardsNeedReset = false;
    const int AmountOfEachColour = 4;
    int cardsFacingForward = 16;
    int pairsMade = 0;

    [HideInInspector]
    public List<Color> ColourPool;
    Color[] colours = { Color.red, Color.blue, Color.yellow, Color.green }; // a pool of colours to give to cards
    [HideInInspector]
    public List<CardBehaviour> clickedCards;
    [HideInInspector]
    public List<CardBehaviour> allCards = new List<CardBehaviour>();

    TutorialPotionsController tutorialPotionsController;
    TurnTick turnTick;


    // Use this for initialization
    void Start ()
    {
        ColourPool = new List<Color>();
        initializeColourPool();

        clickedCards = new List<CardBehaviour>();
        tutorialPotionsController = GameObject.Find("TutorialPotionController").GetComponent<TutorialPotionsController>();
        turnTick = GameObject.Find("Turn-Ticker").GetComponent<TurnTick>();
    }

    private void initializeColourPool()
    {
        ColourPool.Clear();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < AmountOfEachColour; j++)
            {
                ColourPool.Add(colours[i]);
            }
        }

    }

    public void SendCardInfo(CardBehaviour card)
    {
        allCards.Add(card);
    }

    //  checks the two selected cards and returns true if they are the same colour
    private bool CardsAreSame()
    {
        if (clickedCards[0].ThisColour != clickedCards[1].ThisColour)
        {
            turnTick.onTurnTick();
            return false;
        }

        else
        {
            tutorialPotionsController.makePotion(clickedCards[0].ThisColour);
            clickedCards.Clear();
            pairsMade++;
            return true;
        }
    }

    public Color GiveColour(CardBehaviour sender)
    {
        if (ColourPool.Count > 0 && !sender.FacingFront)
        {
            int randnum = Random.Range(0, ColourPool.Count);
            Color returnColour = ColourPool[randnum];
            ColourPool.RemoveAt(randnum);
            return returnColour;
        }
        else
        {
            return Color.white;
        }
    }

    // Update is called once per frame
    void Update ()
    {
		if(clickedCards.Count >= 2 && !CardsAreSame())
        {
            foreach (CardBehaviour card in clickedCards)
            {
                card.unflip();
            }
            clickedCards.Clear();
        }

        if(pairsMade >= 8)
        {
            initializeColourPool();
            foreach(CardBehaviour card in allCards)
            {
                card.CardNeedsReset = true;
            }
            pairsMade = 0;
        }
	}
}
