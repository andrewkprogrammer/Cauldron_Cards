using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGridController : MonoBehaviour {

    //public bool cardsNeedReset = false;
    const int AmountOfEachColour = 4;
    int cardsFacingForward = 16;
    int pairsMade = 0;
    float ShuffleTimer;
    float PotionThrowTimer;
    float flipTimer;

    [HideInInspector]
    public bool ClickedCardsNeedFlip = false;
    [HideInInspector]
    public List<Color> ColourPool;
    Color[] colours = { Color.red, Color.blue, Color.yellow, Color.green }; // a pool of colours to give to cards
    [HideInInspector]
    public List<CardBehaviour> clickedCards;
    [HideInInspector]
    public List<CardBehaviour> allCards = new List<CardBehaviour>();

    Material[] Textures;
    List<Material> TexturePool;

    TutorialPotionsController tutorialPotionsController;
    TurnTick turnTick;

    Animator CatAnimator;

    List<Color> throwQueue;

    // Use this for initialization
    void Start ()
    {
        ColourPool = new List<Color>();
        TexturePool = new List<Material>();
        Material[] tempTextures = { Resources.Load<Material>("Herb_Mat"), Resources.Load<Material>("Mushroom_Mat"), Resources.Load<Material>("Ore_Mat"), Resources.Load<Material>("Root_Mat") };
        tempTextures[0].name = "Herb";
        tempTextures[1].name = "Mushroom";
        tempTextures[2].name = "Ore";
        tempTextures[3].name = "Root";
        Textures = tempTextures;
        initializeColourPool();

        CatAnimator = GameObject.Find("Cat_Model").GetComponent<Animator>();

        clickedCards = new List<CardBehaviour>();
        tutorialPotionsController = GameObject.Find("TutorialPotionController").GetComponent<TutorialPotionsController>();
        turnTick = GameObject.Find("Turn-Ticker").GetComponent<TurnTick>();
        throwQueue = new List<Color>();

        StartCoroutine(setStartCardMaterial());
    }

    IEnumerator setStartCardMaterial() // this is the initial function for setting each card's texture
    {
        yield return new WaitForEndOfFrame();
        foreach(var c in allCards)
        {
            Material randMat = GiveMat();
            c.thisMaterial = randMat;
            c.thisMaterial.name = randMat.name;
        }

    }

    private void initializeColourPool() //this function is called prior to giving each card a texture
    {
        
        for( int i = 0; i < 4; i++)
        {
            for(int j = 0; j < AmountOfEachColour; j++)
            {
                TexturePool.Add(Textures[i]);
            }
        }

    }

    public void SendCardInfo(CardBehaviour card) //each card calls this function to add itself to "allCards"
    {
        allCards.Add(card);
    }

    //  checks the two selected cards and returns true if they are the same colour
    private bool CardsAreSame()
    {
        if (clickedCards[0].thisMaterial.name != clickedCards[1].thisMaterial.name && !ClickedCardsNeedFlip)
        {
            turnTick.onTurnTick();
            return false;
        }
        else if(ClickedCardsNeedFlip)
        {
            return false;
        }
        else
        {
            throwPotion();
            clickedCards.Clear();
            pairsMade++;
            return true;
        }
        
    }

    void throwPotion() //a function telling the potion controller to make a potion of a certain colour
    {
        if (clickedCards[0].thisMaterial.name == "Root")
            throwQueue.Add(Color.red);
        else if (clickedCards[0].thisMaterial.name == "Ore")
            throwQueue.Add(Color.yellow);
        else if (clickedCards[0].thisMaterial.name == "Mushroom")
            throwQueue.Add(Color.blue);
        else if (clickedCards[0].thisMaterial.name == "Herb")
            throwQueue.Add(Color.green);
    }

    public Material GiveMat() //this function is called by each card when it needs a new texture
    {
        int randnum = Random.Range(0, TexturePool.Count);
        Material returnTexture = TexturePool[randnum];
        TexturePool.RemoveAt(randnum);
        return returnTexture;
    }

    // Update is called once per frame
    void Update ()
    {
		if(clickedCards.Count >= 2 && !CardsAreSame()) // if cards are different, they get unflipped, otherwise they stay flipped and a potion is thrown
        {
            ClickedCardsNeedFlip = true;
        }

        if (ClickedCardsNeedFlip)
        {
            flipTimer += Time.deltaTime;
            if (flipTimer >= 1.0f)
            {
                foreach (CardBehaviour card in clickedCards)
                {
                    card.unflip();
                }
                clickedCards.Clear();
                ClickedCardsNeedFlip = false;
                flipTimer = 0.0f;
            }
        }

        if (throwQueue.Count > 0)
        {
            CatAnimator.SetBool("Is_Happy", true);
            PotionThrowTimer += Time.deltaTime;
            if (PotionThrowTimer >= 1.0f)
            {
                tutorialPotionsController.makePotion(throwQueue[0]);
                throwQueue.RemoveAt(0);
                PotionThrowTimer = 0.0f;
            }

        }
        else
        {
            CatAnimator.SetBool("Is_Happy", false);
        }


        if (pairsMade >= 8)
            Reshuffle();
    }

    void Reshuffle() // once 8 pairs are made (the total possible at once) the cards are reshuffled)
    {
        if (TexturePool.Count == 0)
            initializeColourPool();

        ShuffleTimer += Time.deltaTime;

        if (ShuffleTimer > 3.5f)
        {
            pairsMade = 0;
            ShuffleTimer = 0.0f;
            foreach (CardBehaviour card in allCards)
            {
                if (card != null)
                    card.thisMaterial = GiveMat();
            }
        }
        else if (ShuffleTimer > 1.7f)
        {
            foreach (CardBehaviour card in allCards)
            {
                if (card.Front_Showing)
                    card.unflip();
            }
        }
    }
}
