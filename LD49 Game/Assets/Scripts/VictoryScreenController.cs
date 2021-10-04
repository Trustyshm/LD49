using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class VictoryScreenController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public ScoreController scoreController;
    public Timer timer;
    private SmashCounter smashCounter;

    private AudioSource audioSource;
    public AudioClip doorSound;

   

    [System.NonSerialized]
    public int theScore;

    [System.NonSerialized]
    public int numSmashes;

    private GameObject fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("LevelSFX").GetComponent<AudioSource>();
        smashCounter = GameObject.FindGameObjectWithTag("TheScore").GetComponent<SmashCounter>();
        fadeOut = GameObject.FindGameObjectWithTag("FaderOut");
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
            //theScore = scoreController.GetScore();
            //numSmashes = smashCounter.smashedObjects;
            fadeOut.transform.GetChild(0).gameObject.SetActive(true);
            audioSource.clip = doorSound;
            audioSource.Play();
            Invoke("ChangeVictory", 1f);
        }
    }

    private void ChangeVictory()
    {
        if (smashCounter.currentBill < 750)
        {
            SceneManager.LoadScene("VictoryHappy");
        }
        if (smashCounter.currentBill >= 750)
        {
            SceneManager.LoadScene("VictorySad");
        }

    }
}
