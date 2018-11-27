using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CardBehaviour : MonoBehaviour, IPointerClickHandler
 {
    [HideInInspector]
    public bool Front_Showing = false;
    [HideInInspector]
    public Color ThisColour;
    [HideInInspector]
    public Material thisMaterial;
    [HideInInspector]
    public bool FacingFront = true;
    [HideInInspector]
    public bool CardNeedsReset = false;


    float timer = 0.0f;
    CardGridController CardController;
    Animator animator;


    SoundTrigger emitter;

    void Start()
    {
        CardController = (CardGridController)GameObject.Find("Card_Grid").GetComponent(typeof(CardGridController));
        animator = GetComponent<Animator>();
        ThisColour = Color.white;
        CardController.SendCardInfo(this);
        thisMaterial = GetComponent<MeshRenderer>().material;
        emitter = GetComponent<SoundTrigger>();
    }

    public void OnPointerClick(PointerEventData eventData) // runs when a card is clicked/tapped
     {
        if (!Front_Showing && !CardNeedsReset && !CardController.ClickedCardsNeedFlip)
        {
            animator.SetTrigger("Display");
            Front_Showing = true;
            CardController.clickedCards.Add(this);
            emitter.playSound();
        }
     }

    public void unflip() // this function simply flips the card to its back 
    {
        animator.SetTrigger("Reset");
        Front_Showing = false;
        emitter.playSound();
    }

    private void reset() //this function runs when all cards have been matched up
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

     // Update is called once per frame
     void Update()
     {

        if(!thisMaterial.Equals(GetComponent<MeshRenderer>().material))
        {
            GetComponent<MeshRenderer>().material = thisMaterial;
        }

        if (CardNeedsReset)
            reset();
        
     }
}
