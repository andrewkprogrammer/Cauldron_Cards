using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

    Text text_box;

    float time;
    public float fadein_time;
    public float displaypause_time;
    public float fadeout_time;
    Color lt_red;

    bool isFadingIn;
    bool isDisplayPaused;
    bool isFadingOut;

    // Use this for initialization
    void Start () {
        text_box = this.gameObject.GetComponent<Text>();
        lt_red = text_box.color;
        text_box.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (isFadingIn)
        {
            float fadein_percent = time / fadein_time;
            text_box.color = Color.Lerp(lt_red, Color.clear, fadein_percent);
            if (time >= fadein_time)
            {
                time = 0.0f;
                isDisplayPaused = true;
                isFadingIn = false;
            }
        }
        else if (isDisplayPaused)
        {
            if (time >= displaypause_time)
            {
                time = 0.0f;
                isDisplayPaused = false;
                isFadingOut = true;
            }
        }
        else if (isFadingOut)
        {
            float fadeout_percent = time / fadeout_time;
            text_box.color = Color.Lerp(Color.clear, lt_red, fadeout_percent);

            if (time >= fadeout_time)
            {
                isFadingOut = false;
            }
        }
    }

    public void runText(int damage)
    {
        text_box.text = damage.ToString();
        time = 0.0f;
        isFadingIn = true;

    }
}
