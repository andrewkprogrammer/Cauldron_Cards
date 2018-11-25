using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGridController : MonoBehaviour {

    //public bool cardsNeedReset = false;
    const int AmountOfEachColour = 4;
    int cardsFacingForward = 16;
    int pairsMade = 0;
    float timer;

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

        StartCoroutine(setStartCardMaterial());
    }

    IEnumerator setStartCardMaterial()
    {
        yield return new WaitForEndOfFrame();
        foreach(var c in allCards)
        {
            Material randMat = GiveMat();
            c.thisMaterial = randMat;
            c.thisMaterial.name = randMat.name;
        }

    }

    private void initializeColourPool()
    {
        ColourPool.Clear();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < AmountOfEachColour; j++)
            {
                ColourPool.Add(colours[i]);
            }
        }
        
        for( int i = 0; i < 4; i++)
        {
            for(int j = 0; j < AmountOfEachColour; j++)
            {
                TexturePool.Add(Textures[i]);
            }
        }

    }

    public void SendCardInfo(CardBehaviour card)
    {
        allCards.Add(card);
    }

    //  checks the two selected cards and returns true if they are the same colour
    private bool CardsAreSame()
    {
        if (clickedCards[0].thisMaterial.name != clickedCards[1].thisMaterial.name)
        {
            turnTick.onTurnTick();
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

    void throwPotion()
    {
        if(clickedCards[0].thisMaterial.name == "Root")
            tutorialPotionsController.makePotion(Color.red);
        else if(clickedCards[0].thisMaterial.name == "Ore")
            tutorialPotionsController.makePotion(Color.yellow);
        else if (clickedCards[0].thisMaterial.name == "Mushroom")
            tutorialPotionsController.makePotion(Color.blue);
        else if (clickedCards[0].thisMaterial.name == "Herb")
            tutorialPotionsController.makePotion(Color.green);
    }

    public Material GiveMat()
    {
        int randnum = Random.Range(0, TexturePool.Count);
        Material returnTexture = TexturePool[randnum];
        TexturePool.RemoveAt(randnum);
        return returnTexture;
    }

    // Update is called once per frame
    void Update ()
    {
		if(clickedCards.Count >= 2 && !CardsAreSame())
        {
            foreach (CardBehaviour card in clickedCards)
            {
                card.unflip();
            }
            clickedCards.Clear();
        }

        if(pairsMade >= 8)
        {
            if(TexturePool.Count != 0)
            initializeColourPool();

            timer += Time.deltaTime;

            if (timer > 3.5f)
            {
                foreach(CardBehaviour card in allCards)
                    card.thisMaterial = GiveMat();
                pairsMade = 0;
                timer = 0.0f;
            }
            else if (timer > 1.7f)
            {
                foreach (CardBehaviour card in allCards)
                {
                    if(!card.Front_Showing)
                    card.unflip();
                }
            }

        }
	}
}
