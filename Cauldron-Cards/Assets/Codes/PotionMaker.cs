using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour {

    //Image
    GameObject spider;
    GameObject throwStart;

    public GameObject animatedCloud;
    public string colour_name;


    Vector3 start_pos;
    Vector3 spider_pos;

    SpiderController spidercontrols;
    
    float throw_t = 0.0f;
    float gravity = -50.0f;
    float yvel = 25.0f;

    SoundTrigger emitter;

    void Start()
    {
        throwStart = GameObject.FindGameObjectWithTag("ThrowStart");
        start_pos = throwStart.transform.position;
        transform.position = start_pos;
        spider = GameObject.Find("SpiderObject");
        spider_pos = spider.transform.position;
        spidercontrols = spider.GetComponent<SpiderController>();
        emitter = GetComponent<SoundTrigger>();
    }
    void Update()
    {
        throw_t += Time.deltaTime;
        
        Vector3 updated_pos;
        
        updated_pos.x = start_pos.x + (spider_pos.x - start_pos.x) * throw_t;
        updated_pos.y = start_pos.y + yvel * throw_t + (0.5f * gravity * throw_t * throw_t);
        transform.position = new Vector3(updated_pos.x, updated_pos.y, start_pos.z);
        
        if (throw_t >= 1.0f)
        {
            int damage = 2;
            spidercontrols.applyDamage(damage);
            Instantiate(animatedCloud);
            string elemental = "";
            if (colour_name == "red") { elemental = "Fire"; }
            else if (colour_name == "yellow") { elemental = "Electricity"; }
            else if (colour_name == "green") { elemental = "Grass"; }
            else if (colour_name == "blue") { elemental = "Ice"; }
            emitter.setParameter(elemental, 1.0f);
            emitter.playSound();
            Destroy(gameObject);
        
        }
    }
}
