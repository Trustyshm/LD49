using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    [System.NonSerialized]
    public float timerSeconds;
    [System.NonSerialized]
    public int timerMinutes;
    private bool gameRunning;

    // Start is called before the first frame update
    void Start()
    {
        gameRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            UpdateTimerUI();
        }
        
    }

    public void ResetTimer()
    {
        timerText.text = "00:00";
    }

    public void StartTimer()
    {
        gameRunning = true;
    }

    public void StopTimer()
    {
        gameRunning = false;
    }


    public void UpdateTimerUI()
    {
        //set timer UI
        timerSeconds += Time.deltaTime;
        if (timerSeconds < 10)
        {
            if (timerMinutes < 10)
            {
                timerText.text = "0" + timerMinutes + ":0" + (int)timerSeconds;
            }
            else
            {
                timerText.text = timerMinutes + ":0" + (int)timerSeconds;
            }
        }

        else
        {
            if (timerMinutes < 10)
            {
                timerText.text = "0" + timerMinutes + ":" + (int)timerSeconds;
            }
            else
            {
                timerText.text = timerMinutes + ":" + (int)timerSeconds;
            }

        }
        
        if (timerSeconds >= 60)
        {
            timerMinutes++;
            timerSeconds = 0;
        }


    }
}
