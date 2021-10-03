using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSmashedController : MonoBehaviour
{
    private ObjectSmashAlert smashAlert;
    public GameObject smashedItem;
    public GameObject regularItem;

    // Start is called before the first frame update
    void Start()
    {
        smashAlert = gameObject.GetComponent<ObjectSmashAlert>();
        smashedItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        smashedItem.transform.position = regularItem.transform.position;
        smashedItem.transform.rotation = regularItem.transform.rotation;
    }

    public void DoThis()
    {
            Debug.Log("Smashed!");
            smashAlert.ObjectSmashed();
            regularItem.SetActive(false);
            smashedItem.SetActive(true);
            //this.gameObject.SetActive(false);
     }
}
