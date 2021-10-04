using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{

    public AudioClip selectTimer;
    public AudioClip buttonPress;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTimer()
    {
        audioSource.clip = selectTimer;
        audioSource.Play();
    }

    public void StopTimer()
    {
        audioSource.Stop();
    }

    public void PlayButtonPress()
    {
        audioSource.PlayOneShot(buttonPress);
    }
}
