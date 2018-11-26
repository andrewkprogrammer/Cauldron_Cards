using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTransition : MonoBehaviour {

    public float fadeTime;
    float time;

    float start_alpha;
    float end_alpha;
    CanvasGroup canvas;
    public bool isFadingIn;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<CanvasGroup>();
        if (isFadingIn) { fadeInFromBlack(); }
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        float percentComplete = time / fadeTime;

        float opacity = Mathf.Lerp(start_alpha, end_alpha, percentComplete);
        canvas.alpha = opacity;

	}

    public void fadeInFromBlack()
    {
        start_alpha = 1.0f;
        end_alpha = 0.0f;
        time = 0.0f;
    }

    public void fadeOutToBlack()
    {
        start_alpha = 0.0f;
        end_alpha = 1.0f;
        time = 0.0f;
    }
}
