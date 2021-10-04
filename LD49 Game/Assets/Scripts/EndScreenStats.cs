using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenStats : MonoBehaviour
{

    private ScoreController scoreController;
    private SmashCounter smashCounter;
    public TextMeshProUGUI smashedObjects;
    public TextMeshProUGUI bill;
    public TextMeshProUGUI levelTime;

    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.FindGameObjectWithTag("TheScore").GetComponent<ScoreController>();
        smashCounter = GameObject.FindGameObjectWithTag("TheScore").GetComponent<SmashCounter>();
        smashedObjects.text = smashCounter.smashedObjects.ToString();
        bill.text = smashCounter.currentBill.ToString();
        scoreController.GetScore();
        if (scoreController.timerSeconds < 10)
        {
            if (scoreController.timerMinutes < 10)
            {
                levelTime.text = "0" + scoreController.timerMinutes + ":0" + scoreController.timerSeconds;
            }
            else
            {
                levelTime.text = scoreController.timerMinutes + ":0" + scoreController.timerSeconds;
            }

        }
        else
        {
            if (scoreController.timerMinutes < 10)
            {
                levelTime.text = "0" + scoreController.timerMinutes + ":" + scoreController.timerSeconds;
            }
            else
            {
                levelTime.text = scoreController.timerMinutes + ":" + scoreController.timerSeconds;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
