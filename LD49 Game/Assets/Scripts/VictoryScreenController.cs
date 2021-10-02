using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScreenController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public ScoreController scoreController;
    public TextMeshProUGUI victoryScore;
    public Timer timer;
    public TextMeshProUGUI victoryTime;
    public SmashCounter smashCounter;
    public TextMeshProUGUI victorySmashes;

    // Start is called before the first frame update
    void Start()
    {
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
            victoryScore.text = scoreController.GetScore().ToString();
            victoryTime.text = timer.timerText.text;
            victorySmashes.text = smashCounter.smashedObjects.ToString();
            Debug.Log("You Won");
        }
    }
}
