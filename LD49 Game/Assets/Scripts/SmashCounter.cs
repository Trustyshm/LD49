using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class SmashCounter : MonoBehaviour
{

    public TextMeshProUGUI smashedCounter;

    [System.NonSerialized]
    public int smashedObjects;

    [System.NonSerialized]
    public int currentBill;

    // Start is called before the first frame update
    void Start()
    {


       
    }

    public void RegisterObjects()
    {
        foreach (GameObject smashAlert in GameObject.FindGameObjectsWithTag("Smashable"))
        {
            smashAlert.GetComponent<ObjectSmashAlert>().OnObjectSmashed += AddSmash;
        }
        smashedCounter.text = "0";
        currentBill = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSmash(int number)
    {
        smashedObjects++;
        //smashedCounter.text = smashedObjects.ToString();
        currentBill += Random.Range(10, 22);
        smashedCounter.text = currentBill.ToString();

    }

    public void ResetSmash()
    {
        smashedObjects = 0;
        smashedCounter.text = "0";
    }
}
