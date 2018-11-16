using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour {

    //Image

    Vector2 start_pos;
    Vector2 spider_pos;

    float angle;
    float throwPower;
    float deltaTimeMultiplier = 1.0f;
    float throw_t = 0.0f;
    float gravity = -9.8f;

    bool isThrowing = false;


    void Update()
    {
        if (isThrowing)
        {
            throw_t += Time.deltaTime * deltaTimeMultiplier;

            Vector2 updated_pos;

            updated_pos.x = start_pos.x + (spider_pos.x - start_pos.x) * throw_t;
            updated_pos.y = start_pos.y + (spider_pos.y - start_pos.y) * throw_t + (0.5f * gravity * throw_t * throw_t);

            transform.position = updated_pos;
            Debug.Log(this.ToString() + " throw.");
            if (throw_t >= 1.0f)
            {
                isThrowing = false;
            }
        }
    }

    public void makePotion()
    {
        gameObject.SetActive(true);
        Debug.Log(this.ToString() + " made.");
        throwPotion();
    }

    void throwPotion()
    {
        start_pos = GameObject.Find("ThrowStart").transform.position;
        transform.position = start_pos;
        spider_pos = GameObject.Find("SpiderObject").transform.position;
        isThrowing = true;
    }
}
