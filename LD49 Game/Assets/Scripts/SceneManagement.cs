using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    private GameObject playerCharacter;
    private Transform startingPosition;

    public Timer theTimer;
    public SmashCounter smashCounter ;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("ThePlayer");
        startingPosition = playerCharacter.transform;

    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        theTimer.ResetTimer();
        smashCounter.smashedObjects = 0;
        //Do Transition Animation
        pauseMenu.SetActive(false);
        playerCharacter.transform.position = startingPosition.position;
        playerCharacter.transform.rotation = startingPosition.rotation;
        //Reset breakables

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NewLevel()
    {
        SceneManager.LoadScene("MainScene");
    }
}
