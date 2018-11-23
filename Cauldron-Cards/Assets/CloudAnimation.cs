using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimation : MonoBehaviour {

    public float delay=0.0f;
    Vector3 spider_pos;

    Vector3 offset = new Vector3(0.0f ,1.75f, -7.0f);

    void Start()
    {
        spider_pos = GameObject.Find("SpiderObject").transform.position;
        transform.position = spider_pos + offset;
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
