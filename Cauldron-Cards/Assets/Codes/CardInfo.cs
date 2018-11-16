using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardInfo
{

    public enum CardColour : int
    {
        Red = 1,
        Blue = 2,
        Yellow = 3,
        Green = 4,

        White = 0 //white exists as a type of "null" value
    }

    const int AmountOfEachColour = 4;
    int numberOfClickedCards = 0;

    List<CardBehaviour> clickedCards;
    List<CardColour> ColourPool;
    CardColour SelectedColour;
    CardColour[] colours = { CardColour.Red, CardColour.Blue, CardColour.Yellow, CardColour.Green }; // a pool of colours to give to cards

    // Use this for initialization
    public CardInfo()
    {
        ColourPool = new List<CardColour>();
        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < AmountOfEachColour; j++)
            {
                ColourPool.Add(colours[i]);
            }
        }

        clickedCards = new List<CardBehaviour>();

    }




//_________________________________________________________________________________


    //  adds a card to the list of cards, typically this should only consist of two cards at most
    public void AddCard(CardColour colour, CardBehaviour sender) 
    {
        numberOfClickedCards++;
        SelectedColour = colour;
        clickedCards.Add(sender);
    }

    //  each card uses this function when it's made to decide what colour it should be
    //  without having too many of the same colour
    public CardColour GiveColour()
    {
        if (ColourPool.Count > 0)
        {
            int randnum = Random.Range(0, ColourPool.Count);
            CardColour returnColour = ColourPool[randnum];
            ColourPool.RemoveAt(randnum);
            return returnColour;
        }
        else
        {
            return CardColour.White;
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
        }
    }
}
