using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyInteraction : MonoBehaviour
{
    public float pushPower = 8.0F;
    private AudioSource audioSource;
    public AudioClip oof;


     void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("LevelSFX").GetComponent<AudioSource>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        //audioSource.PlayOneShot(oof);
        body.velocity = pushDir * pushPower;
    }




}
