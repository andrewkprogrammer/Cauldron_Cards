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


     // Use this for initialization
    void Start()
    {
        CardController = (CardGridController)GameObject.Find("Card_Grid").GetComponent(typeof(CardGridController));
        animator = GetComponent<Animator>();
        ThisColour = Color.white;
        CardController.SendCardInfo(this);
        thisMaterial = GetComponent<MeshRenderer>().material;
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
