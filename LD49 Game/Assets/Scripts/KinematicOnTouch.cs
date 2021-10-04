using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicOnTouch : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider colliderBox;
    public GameObject[] tablePieces;


    public bool isTable;
    public bool glassTable;
    public GameObject tableBreak;

    public bool isWooden;

    private AudioSource audioSource;
    public AudioClip woodSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("LevelSFX").GetComponent<AudioSource>();
        colliderBox = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    private void Update()
    {

    }


    public void Touched()
    {
       if (isTable)
        {
            if (glassTable)
            {
                colliderBox.enabled = false;
                rb.isKinematic = false;
                rb.AddRelativeForce(Random.onUnitSphere * 5);
                tableBreak.SetActive(true);
                
                
            }
            else
            {
                if (rb.isKinematic)
                {
                    audioSource.PlayOneShot(woodSound);
                }
                rb.isKinematic = false;
                colliderBox.isTrigger = false;
                rb.AddRelativeForce(Random.onUnitSphere * 5);
                foreach (GameObject tablePiece in tablePieces)
                {
                    tablePiece.GetComponent<Rigidbody>().isKinematic = false;
                    tablePiece.GetComponent<BoxCollider>().isTrigger = false;
                    tablePiece.GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * 5);
                }
            }
            
        }
        else
        {
            if (rb.isKinematic)
            {
                audioSource.PlayOneShot(woodSound);
            }
            rb.isKinematic = false;
            colliderBox.isTrigger = false;
            rb.AddRelativeForce(Random.onUnitSphere * 5);
        }
            
            

    }




}
