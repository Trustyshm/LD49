using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSmashAlert : MonoBehaviour
{

    public event Action<int> OnObjectSmashed = delegate {};
    private bool doOnce;

    // Start is called before the first frame update
    void Start()
    {
        doOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectSmashed()
    {
        if (!doOnce)
        {

            OnObjectSmashed(1);
            doOnce = true;
        }
        
    }
}
