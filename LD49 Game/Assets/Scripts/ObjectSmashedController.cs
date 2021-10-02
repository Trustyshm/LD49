using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSmashedController : MonoBehaviour
{
    public ObjectSmashAlert smashAlert;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1.5)
        {
            smashAlert.ObjectSmashed();
            //Swap Object
            this.gameObject.SetActive(false);
        }
    }
}
