using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInteract : MonoBehaviour
{

    public bool isStart;
    public bool isSettings;
    public bool isQuit;

    public GameObject player;
    public Animator cameraAnim;

    public GameObject startScreen;
    public GameObject settingsMenu;

    public float maxTimer;
    private float timer;

    public Image fillImage;

    private bool startTimer;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = false;
        timer = maxTimer;
        startScreen.SetActive(false);
        settingsMenu.SetActive(false);
        fillImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;

            fillImage.fillAmount = timer / maxTimer;
        }   

        if (timer <= 0)
        {
            if (isStart)
            {
                StartGame();
            }
            if (isSettings)
            {
                OpenSettings();
            }
            if (isQuit)
            {
                QuitGame();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.CompareTag("ThePlayer"))
        {
            startTimer = true;
            fillImage.enabled = true;
        }
        
        
    }



    private void OnTriggerExit (Collider collision)
    {
        fillImage.enabled = false;
        startTimer = false;
        timer = maxTimer;
        fillImage.fillAmount = 1;
    }



    private void StartGame()
    {
        player.SetActive(false);
        startScreen.SetActive(true);
        cameraAnim.enabled = false;
        Debug.Log("GameStarted");
    }

    private void OpenSettings()
    {
        player.SetActive(false);
        settingsMenu.SetActive(true);
        cameraAnim.enabled = false;
    } 

    private void QuitGame()
    {
        Application.Quit();
    }
}
