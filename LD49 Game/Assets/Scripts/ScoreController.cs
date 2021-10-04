using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public Timer timer;
    private SmashCounter smashCounter;
    private Scene activeScene;

    [System.NonSerialized]
    public string activeSceneName;

    public int timeThresholdOne;
    public int timeThresholdTwo;
    public int timeThresholdThree;
    public int timeThresholdFour;
    public int timeThresholdFive;

    [System.NonSerialized]
    public int timerSeconds;

    [NonSerialized]
    public int timerMinutes = 0;

    public int maxScore;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        activeScene = SceneManager.GetActiveScene();
        activeSceneName = activeScene.name;
    }

    // Start is called before the first frame update
    void Start()
    {
        smashCounter = this.GetComponent<SmashCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetScore()
    {
        
        timerMinutes = timer.timerMinutes;
        timerSeconds = Convert.ToInt32(timer.timerSeconds);
        /*
        int theScore;
        int timeScore = Convert.ToInt32((timer.timerMinutes * 60) + timer.timerSeconds);
        int timeModifier;
        
        if (timeScore < timeThresholdOne)
        {
            timeModifier = 500;
        }
        else if (timeScore < timeThresholdTwo)
        {
            timeModifier = 400;
        }
        else if (timeScore < timeThresholdThree)
        {
            timeModifier = 300;
        }
        else if (timeScore < timeThresholdFour)
        {
            timeModifier = 200;
        }
        else if (timeScore < timeThresholdFive)
        {
            timeModifier = 100;
        }
        else
        {
            timeModifier = 0;
        }


        theScore = maxScore + timeModifier;

        return theScore;*/
    }
}
