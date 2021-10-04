using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour
{
    private ScoreController scoreController;
    public GameObject fadeOut;
    private string previousLevel;

    private bool doOnce;

    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.FindGameObjectWithTag("TheScore").GetComponent<ScoreController>();
        doOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   

    public void NextLevel()
    {
        fadeOut.transform.GetChild(0).gameObject.SetActive(true);
        previousLevel = scoreController.activeSceneName;
        Destroy(scoreController.gameObject);
        Invoke("SelectLevel", 2f);
    }

    public void RetryLevel()
    {
        if (!doOnce)
        {
            doOnce = true;
            fadeOut.transform.GetChild(0).gameObject.SetActive(true);
            previousLevel = scoreController.activeSceneName;
            Invoke("TransferScene", 2f);
            Destroy(scoreController.gameObject);
        }
        
       
    }

    private void SelectLevel()
    {
        Debug.Log(previousLevel);
        if (previousLevel == "LevelOne")
        {
            SceneManager.LoadScene("LevelTwo");
        }
        if (previousLevel == "LevelTwo")
        {
            SceneManager.LoadScene("LevelThree");
        }
        if (previousLevel == "LevelThree" || previousLevel == "RandomLevel")
        {
            SceneManager.LoadScene("RandomLevel");
        }
    }

    private void TransferScene()
    {
        SceneManager.LoadScene(previousLevel);
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
