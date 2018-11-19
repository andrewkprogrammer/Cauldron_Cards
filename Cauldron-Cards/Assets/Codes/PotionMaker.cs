using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour {

    //Image
    GameObject spider;

    Vector2 start_pos;
    Vector2 spider_pos;

    SpiderController spidercontrols;

    float deltaTimeMultiplier = 1.0f;
    float throw_t = 0.0f;
    float gravity = -100.0f;
    float yvel = 50.0f;

    float spinSpeed = -500.0f;


    private void Start()
    {
        start_pos = GameObject.Find("ThrowStart").transform.position;
        transform.position = start_pos;
        spider = GameObject.Find("SpiderObject");
        spider_pos = spider.transform.position;
        spidercontrols = spider.GetComponent<SpiderController>();
    }
    void Update()
    {

        throw_t += Time.deltaTime * deltaTimeMultiplier;

        Vector2 updated_pos;

        updated_pos.x = start_pos.x + (spider_pos.x - start_pos.x) * throw_t;
        updated_pos.y = start_pos.y + yvel * throw_t + (0.5f * gravity * throw_t * throw_t);
        transform.position = updated_pos;

        if (throw_t >= 1.0f)
        {
            int damage = Random.Range(1, 5);
            spidercontrols.applyDamage(damage);
            Destroy(this.gameObject);
            //Play smash animations and sounds
        }

    }
}
