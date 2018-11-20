using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CardBehaviour : MonoBehaviour, IPointerClickHandler
 {
    
    
    static CardInfo cardInfo;

    bool Front_Showing = false;
    float timer = 0.0f;

    public Color ThisColour;
    
    Animator animator;
    public bool FacingFront = true;
    //GameObject umpire;
    

    void Start()
    {
        if (cardInfo == null)
        {
            cardInfo = new CardInfo();
        }
        animator = GetComponent<Animator>();
        ThisColour = Color.white;

        cardInfo.allCards.Add(this);

        //umpire = GameObject.Find("CardUmpire");
    }

    public void OnPointerClick(PointerEventData eventData)
     {
        if (!Front_Showing)
        {
            animator.SetTrigger("Display");
            Front_Showing = true;
            cardInfo.AddCard(ThisColour, this);
            cardInfo.Update();
        }
     }

     // Use this for initialization


     // Update is called once per frame
     void Update()
     {
        if(ThisColour == Color.white)
        {
            ThisColour = cardInfo.GiveColour(this);
            transform.gameObject.GetComponent<MeshRenderer>().material.color = ThisColour;
            
        }

        if (cardInfo.cardsNeedReset)
        {
            timer += Time.deltaTime;
            if (timer > 3.5f)
            {
                ThisColour = Color.white;
                timer = 0.0f;
            }
            else if(timer > 1.7f)
            {
                unflip();
            }
        }


        
     }

    public void unflip()
    {
        animator.SetTrigger("Reset");
        Front_Showing = false;
    }
    
    public void Facing(bool Front)
    {
        if(Front)
            cardInfo.cardsFacingForward++;
        else
            cardInfo.cardsFacingForward--;
    }

    bool allFacingFront()
    {
        bool returnBool = true;
        foreach(CardBehaviour card in cardInfo.allCards)
        {
            if (!card.Front_Showing)
                returnBool = false;
        }
        return returnBool;
    }
}
