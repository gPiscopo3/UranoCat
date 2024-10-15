using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] public int startHour;
    [SerializeField] public int endHour;

    public Time startTime;
    public Time endTime;
    public struct Time

    {
        public int hour;
        public float minute;

        public Time(int hour, float minute)
        {
            this.hour = hour;
            this.minute = minute;
        }
    }
    public Time currentTime;
    public float scaleFactor;

    // Start is called before the first frame update
    void Start()
    {
        startTime.hour = startHour;
        startTime.minute = 0;
        endTime.hour = endHour;
        endTime.minute = 0;
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime.minute += (UnityEngine.Time.deltaTime*scaleFactor);

        if (currentTime.minute >= 60) 
        {
            currentTime.minute = 0;

            if (currentTime.hour < endHour)
                currentTime.hour++;
        }
        if(currentTime.minute <= 9)
        {
            text.SetText("" + currentTime.hour + ":0" + (int)currentTime.minute);
        }
        else
        {
            text.SetText("" + currentTime.hour + ":" + (int)currentTime.minute);
        }

        if(currentTime.hour == endHour)
        {
            scaleFactor = 0;
        }
       
    }

    public float getDayCompletionPercentage()
    {
        //return ((float)(currentTime.hour - startHour)) / ((float)(endHour - startHour));
        return ((float)getCurrentTotalMinutes()) / ((float)(endHour - startHour) * 60);
    }

    public int getCurrentTotalMinutes()
    {
        return (currentTime.hour - startHour)*60 + (int)currentTime.minute;
    }

}
