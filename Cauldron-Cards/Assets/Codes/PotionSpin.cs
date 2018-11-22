using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpin : MonoBehaviour {

    float spinSpeed;

    void Start()
    {
        spinSpeed = Random.Range(130.0f, 200.0f);
    }

    // Update is called once per frame
    void Update () {

        transform.Rotate(Vector3.forward * (spinSpeed * Time.deltaTime));

    }
}
