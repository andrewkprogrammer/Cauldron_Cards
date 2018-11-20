using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBarVisuals : MonoBehaviour {

    float current_percent;
    float prev_percent;

    RectTransform turnBar_RT;
    public float speed;
    float t = 0;

    // Use this for initialization
    void Start() {
        turnBar_RT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {

        if (t < 1)
        {
            //Scaling up the bar
            t += speed * Time.deltaTime * 1.6f;
            float scaling = Mathf.Lerp(prev_percent, current_percent, t);
            turnBar_RT.sizeDelta = new Vector2(scaling * 100, 100);
        }
    }

    public void updateTurnVisuals(float curr, float prev)
    {
        current_percent = curr;
        prev_percent = prev;
        t = 0;
    }
}
