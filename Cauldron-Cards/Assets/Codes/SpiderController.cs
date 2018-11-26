using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderController : MonoBehaviour {

    Vector3 SPDR_start_pos;
    Vector3 SPDR_end_pos;

    GameObject damageObj;
    Text damageText;

    SceneLoaderBehaviour sceneLoaderBehaviour;

    SoundTrigger emitter;
    

    float current_percent;
    public float publicspeed;

    public int health;

    bool isPoisoned;
    bool isFrozen;
    int rollHelper = 0;

    public string nextSceneName;

    // Use this for initialization
    void Start () {
        SPDR_start_pos = GameObject.Find("SpiderStart").transform.position;
        SPDR_end_pos = GameObject.Find("SpiderEnd").transform.position;
        damageObj = GameObject.Find("damageText");
        damageText = damageObj.GetComponent<Text>();
        sceneLoaderBehaviour = GameObject.Find("SceneLoader").GetComponent<SceneLoaderBehaviour>();
        emitter = GetComponent<SoundTrigger>();
    }
	
	// Update is called once per frame
	void Update () {
        
        //Finds the location of the next node to reach
        Vector3 next_pos = Vector3.Lerp(SPDR_start_pos, SPDR_end_pos, current_percent);
        float distanceLeft = Vector3.Distance(transform.position, next_pos);
        float speed = publicspeed * distanceLeft;


        //Moves spider towards the next node
        transform.position = Vector3.MoveTowards(transform.position, next_pos, speed*0.1f);


       
    }

    public void updateTurnVisuals(float currentPercent)
    {
        current_percent = currentPercent;
        emitter.setParameter("Proximity", current_percent);
        emitter.playSound();
    }

    public void applyDamage(int damage)
    {
        health -= damage;
        damageObj.GetComponent<HealthText>().runText(damage);
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
            sceneLoaderBehaviour.loadScene(nextSceneName);
        }
    }

}
