using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnTick : MonoBehaviour {

    TurnBarVisuals elapsedTurnsBar_Script;
    SpiderController spider_Script;

    [Range(5,40)]
    public int Turns_Total;
     int Turns_Elapsed = 0;

    float current_percent;
    float prev_percent;

    SceneLoaderBehaviour sceneLoaderBehaviour;

    SoundTransitionTrigger emitter;
    MusicControls musicControls;
    public float fadeInTime;

    public enum EventType
    {
        GoodEvent,
        BadEvent,
        GameOver,
        Null
    }

    public Dictionary<int, EventType> m_eventList = new Dictionary<int, EventType>();

    // Use this for initialization
    void Start () {
        elapsedTurnsBar_Script = GameObject.Find("Turn_Bar_Elapsed").GetComponent<TurnBarVisuals>();
        for (int i = 0; i < Turns_Total; i++)
        {
            m_eventList[i] = EventType.Null;
        }
        m_eventList[Turns_Total] = EventType.GameOver;  //Example
        //m_eventList[3] = EventType.GoodEvent;
        //m_eventList[5] = EventType.BadEvent;
        spider_Script = GameObject.Find("SpiderObject").GetComponent<SpiderController>();
        sceneLoaderBehaviour = GameObject.Find("SceneLoader").GetComponent<SceneLoaderBehaviour>();
        emitter = GetComponent<SoundTransitionTrigger>();
        musicControls = GameObject.Find("Music Emitter").GetComponent<MusicControls>();
        emitter.playSound();
    }


    void updateTurnVisuals()
    {
        //Gets percentage of completion
        current_percent = ((float)Turns_Elapsed / (float)Turns_Total);
        prev_percent = ((float)(Turns_Elapsed - 1) / (float)Turns_Total);
        spider_Script.updateTurnVisuals(current_percent);
        elapsedTurnsBar_Script.updateTurnVisuals(current_percent, prev_percent);
        emitter.setParameter("Intensity", ((current_percent * 3.0f) + 1.0f));

    }

    public void onTurnTick()
    {
        Turns_Elapsed++;
        updateTurnVisuals();
        EventType eventType = m_eventList[Turns_Elapsed];
        //Some delaying mechanism, so it doesn't trigger immediately
        if (eventType == EventType.GameOver)
        {
            runGameOver();
        }
        //else if (eventType == EventType.GoodEvent)
        //{
        //    runGoodEvent();
        //}
        //else if (eventType == EventType.BadEvent)
        //{
        //    runBadEvent();
        //}
    }

    void runGameOver()
    {
        musicControls.turnOff("Gameover AUD");
    }
}
