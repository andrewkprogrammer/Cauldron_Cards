using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickBehaviour : MonoBehaviour, IPointerClickHandler
 {
    [Tooltip("The time before the card flips back to it's original position \n (for when the character matches the wrong cards)")]
    [Range(0.0f, 10.0f)]
    //float flipTime = 3.0f;

    GameObject parent;

    bool Front_Showing = false;
    //float timer = 0.0f;

    enum CardColour
    {
        Red,
        Blue,
        Yellow,
        Green,
        Orange,
        Purple,
        Cyan,
        Teal,
        Brown,
        White
    }

    static List<ClickBehaviour> clickedCards = new List<ClickBehaviour>();

    static int numberOfClicked = 0;
    static CardColour   selectedColour;
    static CardColour   neededColour = CardColour.Red;
    CardColour          ThisColour;


    Animator animator;
     public void OnPointerClick(PointerEventData eventData)
     {
        if (!Front_Showing)
        {
            animator.SetTrigger("Display");
            Front_Showing = true;
            numberOfClicked++;
            selectedColour = ThisColour;
            clickedCards.Add(this);
            
        }
        //else
        //{
        //    animator.SetTrigger("Reset");
        //    Front_Showing = false;
        //}
     }

     // Use this for initialization
     void Start()
     {
        parent = GameObject.Find("Card_Grid");
        animator = GetComponent<Animator>();
        int cardCol = Random.Range(0, 10);
        if (cardCol == 0 && !IsListColourAtExcess(CardColour.Red))
            ThisColour = CardColour.Red;
        else if (cardCol == 1 && !IsListColourAtExcess(CardColour.Blue))
            ThisColour = CardColour.Blue;
        else if (cardCol == 2 && !IsListColourAtExcess(CardColour.Yellow))
            ThisColour = CardColour.Yellow;
        else if (cardCol == 3 && !IsListColourAtExcess(CardColour.Green))
            ThisColour = CardColour.Green;
        else if (cardCol == 4 && !IsListColourAtExcess(CardColour.Orange))
            ThisColour = CardColour.Orange;
        else if (cardCol == 5 && !IsListColourAtExcess(CardColour.Purple))
            ThisColour = CardColour.Purple;
        else if (cardCol == 6 && !IsListColourAtExcess(CardColour.Cyan))
            ThisColour = CardColour.Cyan;
        else if (cardCol == 7 && !IsListColourAtExcess(CardColour.Teal))
            ThisColour = CardColour.Teal;
        else if (cardCol == 8 && !IsListColourAtExcess(CardColour.Brown))
            ThisColour = CardColour.Brown;
        else if (cardCol == 9 && !IsListColourAtExcess(CardColour.White))
            ThisColour = CardColour.White;
    }

     // Update is called once per frame
     void Update()
     {
        if(Front_Showing && neededColour != selectedColour && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_Forward"))
        {

            foreach(ClickBehaviour card in clickedCards)
            {
                card.flip();
            }
            clickedCards.Clear();
        }
     }

    public void flip()
    {
        animator.SetTrigger("Reset");
        Front_Showing = false;
        //timer = 0.0f;
    }

    bool IsListColourAtExcess(CardColour colour)
    {
        int numInList = 0;

        foreach(ClickBehaviour card in clickedCards)
        {
            if (card.ThisColour == colour)
                numInList++;
        }
        if (numInList > 1)
            return true;
        return false;
    }
 }
