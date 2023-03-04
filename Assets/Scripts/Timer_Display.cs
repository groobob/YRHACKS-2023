using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer_Display : MonoBehaviour
{
    public float time = 300;
    public TMP_Text timerText;

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }

        DisplayTime(time);
    }   

    void DisplayTime(float timeDisplay)
    {
        if(timeDisplay < 0)
        {
            timeDisplay = 0;
        }
        
        float minutes = Mathf.FloorToInt(timeDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
