using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderBehaviour : MonoBehaviour {


    public void loadScene (string nextScene) 
    {
        Scene next = SceneManager.GetSceneByName(nextScene);
        if (next == null)       { Debug.Log("Loading Scene " + nextScene + " failed, check the spelling of inputted string."); }
        else                    { SceneManager.LoadScene(nextScene); }
    }
}
