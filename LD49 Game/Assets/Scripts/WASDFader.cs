using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDFader : MonoBehaviour
{

    public MeshRenderer WASD;
    public MeshRenderer getDoor;

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

    private void OnTriggerEnter(Collider other)
    {
       
        if (!doOnce)
        {
            
            if (other.CompareTag("ThePlayer"))
            {

                doOnce = true;
                StartCoroutine(FadeWASD());
                StartCoroutine(FadeGetDoor());
                Invoke("FadeDelay", 1f);
            }
        
        }
        
        
    }

    private void FadeDelay()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator FadeWASD()
    {
        while (true)
        {
            WASD.material.color = new Color(WASD.material.color.r, WASD.material.color.g, WASD.material.color.b, Mathf.Lerp(WASD.material.color.a, 0, Time.deltaTime * 5));
            yield return null;
        }
        
        
    }

    IEnumerator FadeGetDoor()
    {
        while (true)
        {
            getDoor.material.color = new Color(getDoor.material.color.r, getDoor.material.color.g, getDoor.material.color.b, Mathf.Lerp(getDoor.material.color.a, 0, Time.deltaTime * 5));
            yield return null;
        }
        
    }
}
