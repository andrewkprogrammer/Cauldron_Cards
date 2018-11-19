using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpin : MonoBehaviour {

    public float spinSpeed;

	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.forward * (spinSpeed * Time.deltaTime));

    }
}
