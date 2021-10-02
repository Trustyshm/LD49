using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public Timer timer;
    private SmashCounter smashCounter;

    public int timeThresholdOne;
    public int timeThresholdTwo;
    public int timeThresholdThree;
    public int timeThresholdFour;
    public int timeThresholdFive;

    public int maxScore;

    // Start is called before the first frame update
    void Start()
    {
        smashCounter = this.GetComponent<SmashCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
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

        int smashConsequence = (smashCounter.smashedObjects * 10);

        theScore = maxScore - smashConsequence + timeModifier;

        return theScore;
    }
}
