using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerSkripta : MonoBehaviour
{
    public float timeRemaining;
    bool timerIsRunning = false;
    Text timeText;

    void Start()
    {
        timeText = GameObject.Find("TimerText").GetComponent<Text>();
        // Starts the timer automatically
        timerIsRunning = true;
        timeText.color = new Color(1, 1, 1);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining < 5)
                {
                    timeText.color = new Color(1, 0, 0);
                }
                DisplayTime(timeRemaining);            
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }  

    
}

