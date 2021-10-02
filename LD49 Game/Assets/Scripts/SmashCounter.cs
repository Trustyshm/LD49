using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SmashCounter : MonoBehaviour
{

    public TextMeshProUGUI smashedCounter;

    [System.NonSerialized]
    public int smashedObjects;

    // Start is called before the first frame update
    void Start()
    {


        foreach (GameObject smashAlert in GameObject.FindGameObjectsWithTag("Smashable"))
        {
            smashAlert.GetComponent<ObjectSmashAlert>().OnObjectSmashed += AddSmash;
        }
        smashedCounter.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSmash(int number)
    {
        smashedObjects++;
        smashedCounter.text = smashedObjects.ToString();

    }

    public void ResetSmash()
    {
        smashedObjects = 0;
        smashedCounter.text = "0";
    }
}
