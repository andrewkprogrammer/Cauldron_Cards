using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnTick : MonoBehaviour {

    GameObject elapsedTurnsBar;
    GameObject spider;

    [Range(5,40)]
    public int Turns_Total;
     int Turns_Elapsed = 0;

    RectTransform turnBar_RT;

    public float speed;

    Vector2 SPDR_start_pos;
    Vector2 SPDR_end_pos;

    bool isTurnMoving = false;

    float current_percent;
    float prev_percent;
    float t = 0;

    Text eventTestText;


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
        elapsedTurnsBar = GameObject.Find("Turn_Bar_Elapsed");
        for (int i = 0; i < Turns_Total; i++)
        {
            m_eventList[i] = EventType.Null;
        }
        m_eventList[Turns_Total] = EventType.GameOver;
        m_eventList[3] = EventType.GoodEvent;
        m_eventList[5] = EventType.BadEvent;
        spider = GameObject.Find("SpiderObject");
        turnBar_RT = elapsedTurnsBar.GetComponent<RectTransform>();

        SPDR_start_pos = GameObject.Find("SpiderStart").transform.position;
        SPDR_end_pos = GameObject.Find("SpiderEnd").transform.position;
        eventTestText = GameObject.Find("Event Tests").GetComponent<Text>();
    }


    void Update()
    {
        if (isTurnMoving)
        {


            //Returns start and end position 

            //Finds the location of the next node to reach
            Vector2 next_pos = Vector2.Lerp(SPDR_start_pos, SPDR_end_pos, current_percent);

            //Moves spider towards the next node
            spider.transform.position = Vector2.MoveTowards(spider.transform.position, next_pos, speed);
            

            //Gets the previous node
            prev_percent = ((float)(Turns_Elapsed - 1) / (float)Turns_Total);

            //Scaling up the bar
            t += speed * Time.deltaTime * 1.6f;
            float scaling = Mathf.Lerp(prev_percent, current_percent, t);
            turnBar_RT.sizeDelta = new Vector2(scaling * 100, 100);

            //When turn is complete, reset all the pre-turning parameters, and run any events needed
            if (t >= 1.0f)
            {
                isTurnMoving = false;
                t = 0.0f;
                EventType eventType = m_eventList[Turns_Elapsed];
                if (eventType == EventType.GameOver)
                {
                    runGameOver();
                }
                else if (eventType == EventType.GoodEvent)
                {
                    runGoodEvent();
                }
                else if (eventType == EventType.BadEvent)
                {
                    runBadEvent();
                }

            }
        }
    }

    void updateTurnVisuals()
    {
        //Gets percentage of completion
        current_percent = ((float)Turns_Elapsed / (float)Turns_Total);
        prev_percent = ((float)(Turns_Elapsed - 1) / (float)Turns_Total);
    }

    public void onTurnTick()
    {
        Turns_Elapsed++;
        isTurnMoving = true;
        
        //Other if statements to implement Good and Bad Events
        updateTurnVisuals();
    }

    void runGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void runGoodEvent()
    {
        eventTestText.text = "Good Event";
    }

    void runBadEvent()
    {
        eventTestText.text = "Bad Event";
    }
}
