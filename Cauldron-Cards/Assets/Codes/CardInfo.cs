using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo
{

    public bool cardsNeedReset = false;
    const int AmountOfEachColour = 4;
    int numberOfClickedCards = 0;

    int pairsMade = 0;

    List<CardBehaviour> clickedCards;
    List<Color> ColourPool;
    Color SelectedColour;
    Color[] colours = { Color.red, Color.blue, Color.yellow, Color.green }; // a pool of colours to give to cards

    // Use this for initialization
    public CardInfo()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;

        ColourPool = new List<Color>();
        initializeColourPool();

        clickedCards = new List<CardBehaviour>();

    }




//_________________________________________________________________________________


    private void initializeColourPool()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < AmountOfEachColour; j++)
            {
                ColourPool.Add(colours[i]);
            }
        }
        cardsNeedReset = false;
    }
    //  adds a card to the list of cards, typically this should only consist of two cards at most
    public void AddCard(Color colour, CardBehaviour sender) 
    {
        numberOfClickedCards++;
        SelectedColour = colour;
        clickedCards.Add(sender);
    }

    //  each card uses this function when it's made to decide what colour it should be
    //  without having too many of the same colour
    public Color GiveColour()
    {
        if (ColourPool.Count > 0)
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

    //  checks the two selected cards and returns true if they are the same colour
    private bool CardsAreSame()
    {
        if (clickedCards[0].ThisColour != clickedCards[1].ThisColour)
            return false;
        else
            return true;
    }
//_________________________________________________________________________________



    // Update is called once per frame
    public void Update()
    {
        if(clickedCards.Count == 2 && !CardsAreSame())
        {
            foreach(CardBehaviour card in clickedCards)
            {
                card.unflip();
            }
            clickedCards.Clear();
        }
        else if(clickedCards.Count == 2 && CardsAreSame())
        {
            clickedCards.Clear();
            pairsMade++;
        }

        if(pairsMade >= 8)
        {
            initializeColourPool();
            cardsNeedReset = true;
        }
    }
}
