using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerSpawner : MonoBehaviour
{

    public GameObject beerBottle;


    private Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        Queue<GameObject> beerBottlePool = new Queue<GameObject>();

        for (int i = 0; i < 150; i++)
        {
            GameObject beerBottleObject = Instantiate(beerBottle);
            beerBottleObject.SetActive(false);
            beerBottlePool.Enqueue(beerBottleObject);
        }
        poolDictionary.Add("BeerBottles", beerBottlePool);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnBottles();
    }

    public void SpawnBottles()
    {
        GameObject nextBottle = poolDictionary["BeerBottles"].Dequeue();
        nextBottle.transform.position = new Vector3 (this.transform.localPosition.x + Random.Range(-0.5f, .5f), this.transform.localPosition.y, this.transform.localPosition.z + Random.Range(-0.5f, .5f));
        nextBottle.transform.rotation = this.transform.rotation;
        nextBottle.SetActive(true);

        poolDictionary["BeerBottles"].Enqueue(nextBottle);
    }

}
