using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;

    private TimeSpan timePlayed;
    private bool timerGoing;

    private float elapsedTime;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
        BeginTimer();
    }
 

    public void BeginTimer()
    {
      timerGoing = true;
      elapsedTime = 0f;
      StartCoroutine(UpdateTimer());
    }

    public TimeSpan EndTimer()
    {
        timerGoing = false;
        StopAllCoroutines();
        return timePlayed;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlayed = TimeSpan.FromSeconds(elapsedTime);
            string timePlayedStr = "Time:" + timePlayed.ToString(@"mm\:ss\:fff");
            timeCounter.text = timePlayedStr;
           
            yield return null;
        }
    }

}
