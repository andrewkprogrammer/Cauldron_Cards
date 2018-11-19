using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CardBehaviour : MonoBehaviour, IPointerClickHandler
 {
    
    
    static CardInfo cardInfo;

    bool Front_Showing = false;
    //float timer = 0.0f;

    public Color ThisColour;

    GameObject thisObject;
    Animator animator;
    

    void Start()
    {
        if (cardInfo == null)
        {
            cardInfo = new CardInfo();
        }
        animator = GetComponent<Animator>();
        ThisColour = Color.white;
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
            ThisColour = cardInfo.GiveColour();
            transform.gameObject.GetComponent<MeshRenderer>().material.color = ThisColour;
        }

        if(cardInfo.cardsNeedReset)
        {
            ThisColour = Color.white;
        }


        
     }

    public void unflip()
    {
        animator.SetTrigger("Reset");
        Front_Showing = false;
    }
    
 }
