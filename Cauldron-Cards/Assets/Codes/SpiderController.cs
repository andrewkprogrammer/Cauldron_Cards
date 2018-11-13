using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {

    Vector2 SPDR_start_pos;
    Vector2 SPDR_end_pos;
    

    float current_percent;
    public float publicspeed;

    public int health;

    bool isPoisoned;
    bool isFrozen;
    int rollHelper = 0;

    // Use this for initialization
    void Start () {
        SPDR_start_pos = GameObject.Find("SpiderStart").transform.position;
        SPDR_end_pos = GameObject.Find("SpiderEnd").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        
        //Finds the location of the next node to reach
        Vector2 next_pos = Vector2.Lerp(SPDR_start_pos, SPDR_end_pos, current_percent);
        float distanceLeft = Vector2.Distance(transform.position, next_pos);
        float speed = publicspeed * distanceLeft;


        //Moves spider towards the next node
        transform.position = Vector2.MoveTowards(transform.position, next_pos, speed*0.1f);

    }

    public void updateTurnVisuals(float currentPercent)
    {
        current_percent = currentPercent;
    }

    public void applyDamage(int damage)
    {
        health -= damage;
        healthCheck();
    }

    public void applyPoison()
    {
        if (!isPoisoned)
        {
            isPoisoned = true;
        }
        else
        {
            //Already Posioned function
        }
    }

    public void applyStatusEffects()
    {
        if (!isPoisoned && !isFrozen)
        {
           return;
        }
        else
        {
            attemptStatusEffectCure();
            if (isPoisoned)
            {
                int psn_Damage = Random.Range(1, 5);
                health -= psn_Damage;
            }

        }
        
    }

    void attemptStatusEffectCure()
    {
        int cureRoll = Random.Range(1, 9) + rollHelper;
        if (cureRoll >= 8)
        {
            if (isPoisoned && !isFrozen)
            {
                //poison Cured
            }
            else if (!isPoisoned && isFrozen)
            {
                //frozen Cured
            }
            else if (isPoisoned && isFrozen)
            {
                if (cureRoll % 2 == 0)
                {
                    //poison Cured
                }
                else
                {
                    //frozen cured
                }
            }
            rollHelper = 0;
        }
        else
        {
            rollHelper++;
        }

    }

    void healthCheck()
    {
        if (health <= 0)
        {
            //Run victory functions
        }
    }

}
