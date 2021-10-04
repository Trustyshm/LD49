using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableCollided : MonoBehaviour
{
    // Start is called before the first frame update
    private ObjectSmashedController objectController;

    void Start()
    {
        objectController = GetComponentInParent<ObjectSmashedController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1.2f && collision.gameObject.tag != "AShelf")
        {

            objectController.DoThis();
        }
    }
}
