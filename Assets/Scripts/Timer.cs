using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //Variables
    public static float time = 0;
    public bool timeGoing;

    public TextMeshProUGUI timeText;
    private TimeSpan timePlaying;//TimeSpan for UpdateTimer
    // Start is called before the first frame update
    void Start()
    {
        //Sets text on UI and calls StartTimer function
        timeText.text = "Timer: 00.00";
        StartTimer();
    }
    //Starts corountine
    public void StartTimer()
    {
        timeGoing = true;
        time = 0f;

        StartCoroutine(UpdateTimer());
    }
    //Stops Timer
    public void EndTimer()
    {
        timeGoing = false;
    }
    IEnumerator UpdateTimer()
    {
        while (timeGoing)
        {
            time += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(time);//Gives time to TimeSpan
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss");//Formats the time to readable time
            timeText.text = timePlayingStr;//shows time on end screen

            yield return null;
        }
    }
}
