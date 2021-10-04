using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlScene : MonoBehaviour
{
    public GameObject statsContainer;
    public SpawnerController spawnControl;
    public bool isTutorial;
    public GameObject fader;

    public GameObject textOne;
    public GameObject textTwo;
    public GameObject textThree;
    public GameObject textFour;
    public CanvasGroup canvasGroup;

    public GameObject WASD;
    private GameObject playerObject;
    private PlayerMovement playerMovement;
    private Animator playerAnim;

    private AudioSource audioSource;
    public AudioSource vomitSource;
    public AudioClip vomit;
    public AudioClip textSound;

    void Awake()
    {
        fader.SetActive(true);
        Invoke("DisableFader", 2f);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("LevelSFX").GetComponent<AudioSource>();
        spawnControl.Invoke("PickLevel", 1f);
        if (isTutorial)
        {
            Invoke("DisablePlayer", 1.5f);
            Invoke("StartTexts", 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisableFader()
    {
        fader.SetActive(false);
    }

    private void DisablePlayer()
    {
        playerObject = GameObject.FindGameObjectWithTag("ThePlayer");
        playerMovement = playerObject.GetComponent<PlayerMovement>();
        playerMovement.enabled = false;
    }

    private void StartTexts()
    {
        playerAnim = playerObject.GetComponent<Animator>();
        playerAnim.SetTrigger("Puke");
        vomitSource.clip = vomit;
        vomitSource.PlayDelayed(0.23f);
        StartCoroutine(FirstText());
        StartCoroutine(MoveFirstText(4f, 100));
        StartCoroutine(SecondText());
        StartCoroutine(ThirdText());
        StartCoroutine(MoveFirstText(8f, 260));
        StartCoroutine(MoveSecondText(8f, 100));
        StartCoroutine(FourthText());
        StartCoroutine(MoveFirstText(12f, 410));
        StartCoroutine(MoveSecondText(12f, 260));
        StartCoroutine(MoveThirdText(12f, 100));
        StartCoroutine(FadeOut(16f));
        Invoke("EnablePlayer", 17f);

    }

    IEnumerator FirstText()
    {
        audioSource.clip = textSound;
        audioSource.Play();
        while (true)
        {
            textOne.transform.localScale = new Vector3(Mathf.Lerp(textOne.transform.localScale.x, 1, Time.deltaTime * 3), Mathf.Lerp(textOne.transform.localScale.y, 1, Time.deltaTime * 3), Mathf.Lerp(textOne.transform.localScale.z, 1, Time.deltaTime * 3));
            yield return null;
          //  break;
        }

        //StartCoroutine(MoveFirstText());
        //StartCoroutine(SecondText());
    }

    IEnumerator MoveFirstText(float delay, int position)
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            textOne.transform.localPosition = new Vector3(textOne.transform.localPosition.x, Mathf.Lerp(textOne.transform.localPosition.y, position, Time.deltaTime * 3), textOne.transform.localPosition.z);
            yield return null;
            
        }
    }

    IEnumerator SecondText()
    {
        yield return new WaitForSeconds(4f);
        audioSource.clip = textSound;
        audioSource.Play();
        while (true)
        {
            textTwo.transform.localScale = new Vector3(Mathf.Lerp(textTwo.transform.localScale.x, 1, Time.deltaTime * 3), Mathf.Lerp(textTwo.transform.localScale.y, 1, Time.deltaTime * 3), Mathf.Lerp(textTwo.transform.localScale.z, 1, Time.deltaTime * 3));
            yield return null;

        }


    }

    IEnumerator MoveSecondText(float delay, int position)
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            textTwo.transform.localPosition = new Vector3(textTwo.transform.localPosition.x, Mathf.Lerp(textTwo.transform.localPosition.y, position, Time.deltaTime * 3), textTwo.transform.localPosition.z);
            yield return null;

        }
    }

    IEnumerator ThirdText()
    {
        yield return new WaitForSeconds(8f);
        audioSource.clip = textSound;
        audioSource.Play();
        while (true)
        {
            textThree.transform.localScale = new Vector3(Mathf.Lerp(textThree.transform.localScale.x, 1, Time.deltaTime * 3), Mathf.Lerp(textThree.transform.localScale.y, 1, Time.deltaTime * 3), Mathf.Lerp(textThree.transform.localScale.z, 1, Time.deltaTime * 3));
            yield return null;
        }

    }

    IEnumerator MoveThirdText(float delay, int position)
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            textThree.transform.localPosition = new Vector3(textThree.transform.localPosition.x, Mathf.Lerp(textThree.transform.localPosition.y, position, Time.deltaTime * 3), textThree.transform.localPosition.z);
            yield return null;

        }
    }
    IEnumerator FourthText()
    {
        yield return new WaitForSeconds(12f);
        audioSource.clip = textSound;
        audioSource.Play();
        while (true)
        {
            textFour.transform.localScale = new Vector3(Mathf.Lerp(textThree.transform.localScale.x, 1, Time.deltaTime * 3), Mathf.Lerp(textFour.transform.localScale.y, 1, Time.deltaTime * 3), Mathf.Lerp(textFour.transform.localScale.z, 1, Time.deltaTime * 3));
            yield return null;
        }

    }

    IEnumerator FadeOut(float delay)
    { 
        yield return new WaitForSeconds(delay);
        while (true)
        {

            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0, Time.deltaTime *3f);
            yield return null;
        }
    }

    private void EnablePlayer()
    {
        playerMovement.enabled = true;
    }
}
