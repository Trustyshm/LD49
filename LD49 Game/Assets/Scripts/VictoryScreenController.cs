using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScreenController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public ScoreController scoreController;
    public Timer timer;
    public SmashCounter smashCounter;
   

    [System.NonSerialized]
    public int theScore;

    [System.NonSerialized]
    public int numSmashes;

    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();
        timer = GameObject.FindGameObjectWithTag("TheTimer").GetComponent<Timer>();
        playerMovement = GameObject.FindGameObjectWithTag("ThePlayer").GetComponent<PlayerMovement>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThePlayer"))
        {
            timer.StopTimer();
            playerMovement.roundActive = false;
            theScore = scoreController.GetScore();
            numSmashes = smashCounter.smashedObjects;
            Debug.Log("You Won");
        }
    }
}
