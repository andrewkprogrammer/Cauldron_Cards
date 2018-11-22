using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour {

    //Image
    GameObject spider;

    Vector3 start_pos;
    Vector3 spider_pos;

    SpiderController spidercontrols;

    float deltaTimeMultiplier = 1.0f;
    float throw_t = 0.0f;
    float gravity = -50.0f;
    float yvel = 25.0f;

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

        Vector3 updated_pos;

        updated_pos.x = start_pos.x + (spider_pos.x - start_pos.x) * throw_t;
        updated_pos.y = start_pos.y + yvel * throw_t + (0.5f * gravity * throw_t * throw_t);
        transform.position = new Vector3(updated_pos.x, updated_pos.y, start_pos.z);

        if (throw_t >= 1.0f)
        {
            int damage = Random.Range(1, 5);
            spidercontrols.applyDamage(damage);
            Destroy(gameObject);
            //Play smash animations and sounds
        }

    }
}
