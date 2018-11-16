using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CardBehaviour : MonoBehaviour, IPointerClickHandler
 {
    [Tooltip("The time before the card flips back to it's original position \n (for when the character matches the wrong cards)")]
    [Range(0.0f, 10.0f)]
    //float flipTime = 3.0f;
    

    static CardInfo cardInfo;

    bool Front_Showing = false;
    //float timer = 0.0f;

    public CardInfo.CardColour ThisColour;


    Animator animator;

    void Start()
    {
        if (cardInfo == null)
        {
            cardInfo = new CardInfo();
        }
        animator = GetComponent<Animator>();
        ThisColour = CardInfo.CardColour.White;
    }

    public void OnPointerClick(PointerEventData eventData)
     {
        if (!Front_Showing)
        {
            animator.SetTrigger("Display");
            Front_Showing = true;
            cardInfo.AddCard(ThisColour, this);
        }
        //else
        //{
        //    animator.SetTrigger("Reset");
        //    Front_Showing = false;
        //}
     }

     // Use this for initialization


     // Update is called once per frame
     void Update()
     {
        //if(Front_Showing && neededColour != selectedColour && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_Forward"))
        //{
        //
        //    foreach(CardBehaviour card in clickedCards)
        //    {
        //        card.unflip();
        //    }
        //    clickedCards.Clear();
        //}
        if(ThisColour == CardInfo.CardColour.White)
        {
            ThisColour = cardInfo.GiveColour();
        }

        cardInfo.Update();

     }

    public void unflip()
    {
        animator.SetTrigger("Reset");
        Front_Showing = false;
    }

    //bool IsListColourAtExcess(CardInfo.CardColour colour)
    //{
    //    int numInList = 0;
    //
    //    foreach(CardBehaviour card in clickedCards)
    //    {
    //        if (card.ThisColour == colour)
    //            numInList++;
    //    }
    //    if (numInList > 1)
    //        return true;
    //    return false;
    //}
 }
