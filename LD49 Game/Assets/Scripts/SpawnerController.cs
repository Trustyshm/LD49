using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnerController : MonoBehaviour
{

    public Transform[] spawnSpots;
    public GameObject[] tableBreakables;
    public GameObject[] tables;
    public GameObject[] breakables;
    public SmashCounter smashCounter;

    public Transform playerSpawnSpot;
    public Transform levelSpawnSpot;

    public GameObject[] levels;
    public GameObject player;

    public CinemachineVirtualCamera myCamera;

    private int TableCount;

    private List<GameObject> tableSpots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickLevel()
    {
        int levelIndex = Random.Range(0, levels.Length);
        Instantiate(levels[levelIndex], levelSpawnSpot);
        
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject thePlayer = Instantiate(player, playerSpawnSpot);
        myCamera.LookAt = thePlayer.transform;
        myCamera.Follow = thePlayer.transform;
        CollectTableSpot();
    }

    private void CollectTableSpot()
    {
        foreach (GameObject spawnSpot in GameObject.FindGameObjectsWithTag("TableSpots"))
        {
            tableSpots.Add(spawnSpot);
        }
        SpawnTables();
        
    }


    private void SpawnTables()
    {
        TableCount = 0;
        for (int i = 0; i <= tableSpots.Count -1; i++)
        {
            int Randomizer = Random.Range(0, tables.Length);
            //Spawn Tiered
            Debug.Log(Randomizer);
            if (Randomizer == 0)
            {
                GameObject selectedObject = tables[Randomizer].gameObject;
                Instantiate(selectedObject, tableSpots[i].transform);
            }

            //Spawn Rectangle
            if (Randomizer == 1)
            {
                GameObject selectedObject = tables[Randomizer].gameObject;
                Instantiate(selectedObject, tableSpots[i].transform);
            }
            //Spawn Glass
            if (Randomizer == 2)
            {
                GameObject selectedObject = tables[Randomizer].gameObject;
                
                Instantiate(selectedObject, tableSpots[i].transform.GetChild(1).gameObject.transform);
                Instantiate(selectedObject, tableSpots[i].transform.GetChild(0).gameObject.transform);
            }
            //Spawn Large Vase
            if (Randomizer == 3)
            {
                GameObject selectedObject = tables[Randomizer].gameObject;

                Instantiate(selectedObject, tableSpots[i].transform.GetChild(1).gameObject.transform);
                Instantiate(selectedObject, tableSpots[i].transform.GetChild(0).gameObject.transform);
            }

            TableCount++;
        }
       SpawnTableObjects();
    }

    private void SpawnTableObjects()
    {
        foreach (GameObject spawnSpot in GameObject.FindGameObjectsWithTag("TableSpawn"))
        {
            GameObject selectedObject = tableBreakables[Random.Range(0, tableBreakables.Length)].gameObject;
            Instantiate(selectedObject, spawnSpot.transform);
        }

        SpawnWallObjects();
    }

    private void SpawnWallObjects()
    {
        foreach (GameObject spawnSpot in GameObject.FindGameObjectsWithTag("WallSpawn"))
        {
            GameObject selectedObject = breakables[Random.Range(0, breakables.Length)].gameObject;
            Instantiate(selectedObject, spawnSpot.transform);
        }

        RegisterTheObjects();
    }

    private void RegisterTheObjects()
    {
        smashCounter.RegisterObjects();
    }
}
