using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterSound : MonoBehaviour
{

    public AudioClip soundOne;
    public AudioClip soundTwo;
    public AudioClip soundThree;
    public AudioClip soundFour;
    private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("LevelSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomSound()
    {
        int soundClip = Random.Range(1, 5);
        if (soundClip == 1)
        {
            audioSource.PlayOneShot(soundOne);
        }
        if (soundClip == 2)
        {
            audioSource.PlayOneShot(soundTwo);
        }
        if (soundClip == 3)
        {
            audioSource.PlayOneShot(soundThree);
        }
        if (soundClip == 4)
        {
            audioSource.PlayOneShot(soundFour);
        }
    }
}
