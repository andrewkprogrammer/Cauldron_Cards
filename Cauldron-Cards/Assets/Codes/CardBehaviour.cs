using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CardBehaviour : MonoBehaviour, IPointerClickHandler
 {

    bool Front_Showing = false;
    float timer = 0.0f;

    public Color ThisColour;
    
    Animator animator;
    public bool FacingFront = true;

    CardGridController CardController;

    public bool CardNeedsReset = false;

    void Start()
    {
        CardController = (CardGridController)GameObject.Find("Card_Grid").GetComponent(typeof(CardGridController));
        animator = GetComponent<Animator>();
        ThisColour = Color.white;
        CardController.SendCardInfo(this);

    }

    public void OnPointerClick(PointerEventData eventData)
     {
        if (!Front_Showing && !CardNeedsReset)
        {
            animator.SetTrigger("Display");
            Front_Showing = true;
            CardController.clickedCards.Add(this);
        }
     }

     // Use this for initialization


     // Update is called once per frame
     void Update()
     {

        if (ThisColour == Color.white)
        {
            ThisColour = CardController.GiveColour(this);
            transform.gameObject.GetComponent<MeshRenderer>().material.color = ThisColour;
            
        }

        if (CardNeedsReset)
            reset();
        
     }

    public void unflip()
    {
        animator.SetTrigger("Reset");
        Front_Showing = false;
    }

    private void reset()
    {
        timer += Time.deltaTime;
        if (timer > 3.5f)
        {
            ThisColour = Color.white;
            timer = 0.0f;
            CardNeedsReset = false;
        }
        else if (Front_Showing && timer > 1.7f)
        {
            unflip();
        }

    }

}
