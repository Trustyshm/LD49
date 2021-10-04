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
    public GameObject quitConfirm;

    public MenuSFX menuSFX;

    public float maxTimer;
    private float timer;

    public Image fillImage;

    private bool startTimer;

    private bool doOnce;

    // Start is called before the first frame update
    void Start()
    {
        doOnce = false;

        startTimer = false;
        timer = maxTimer;
        startScreen.SetActive(false);
        quitConfirm.SetActive(false);
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
            doOnce = true;
            timer = maxTimer;
            if (doOnce)
            {
                if (isStart)
                {
                    doOnce = false;
                    StartGame();
                }
                if (isSettings)
                {
                    doOnce = false;
                    OpenSettings();
                }
                if (isQuit)
                {
                   doOnce = false;
                    QuitGame();
                }
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThePlayer"))
        {
            startTimer = true;
            fillImage.enabled = true;
            menuSFX.PlayTimer();
        }
        
        
    }



    private void OnTriggerExit (Collider collision)
    {
        fillImage.enabled = false;
        startTimer = false;
        timer = maxTimer;
        fillImage.fillAmount = 1;
        menuSFX.StopTimer();
    }



    private void StartGame()
    {
        player.SetActive(false);
        startScreen.SetActive(true);
        cameraAnim.enabled = false;
        OnTriggerExit(player.GetComponent<CharacterController>());
    }

    private void OpenSettings()
    {
        player.SetActive(false);
        settingsMenu.SetActive(true);
        cameraAnim.enabled = false;
        OnTriggerExit(player.GetComponent<CharacterController>());
    } 

    private void QuitGame()
    {
        player.SetActive(false);
        cameraAnim.enabled = false;
        quitConfirm.SetActive(true);
        OnTriggerExit(player.GetComponent<CharacterController>());
        
    }


    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void DontQuit()
    {
        player.SetActive(true);
        quitConfirm.SetActive(false);
        cameraAnim.enabled = true;
    }

    public void ExitSettings()
    {
        player.SetActive(true);
        settingsMenu.SetActive(false);
        cameraAnim.enabled = true;
    }
}
