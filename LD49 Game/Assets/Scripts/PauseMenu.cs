using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject settingsMenu;
    public GameObject pauseMenu;

    private PlayerMovement playerMovement;
    public Timer timer;

    private bool toggleBool;


    // Start is called before the first frame update
    void Start()
    {
        toggleBool = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

    }

    public void TogglePause()
    {
        if (playerMovement = null)
        {
            playerMovement = GameObject.FindGameObjectWithTag("ThePlayer").GetComponent<PlayerMovement>();
        }

            toggleBool = !toggleBool;
            pauseMenu.SetActive(toggleBool);
            if (toggleBool)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }

        

    }

    private void OpenMenu()
    {

        playerMovement = GameObject.FindGameObjectWithTag("ThePlayer").GetComponent<PlayerMovement>();
  
        playerMovement.enabled = false;
        timer.StopTimer();
    }

    private void CloseMenu()
    {
        playerMovement = GameObject.FindGameObjectWithTag("ThePlayer").GetComponent<PlayerMovement>();
        playerMovement.enabled = true;
        timer.StartTimer();
    }

    public void ToggleMenu()
    {
        toggleBool = !toggleBool;
    }



    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);        
    }

    public void CloseSettings()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);

    }

    public void ResetLevel()
    {
        Scene theScene;
        theScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(theScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
