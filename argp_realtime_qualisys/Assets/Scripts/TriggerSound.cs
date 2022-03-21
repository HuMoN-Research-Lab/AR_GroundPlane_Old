using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    // reference to the AudioClip we want to play on trigger enter.
    public AudioClip soundTrigger;
    private float velocity; 
    private float previous;


    /// OnTriggerEnter is called when the Collider 'other' enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        velocity = (other.GetComponent<Rigidbody>().position.z - previous) / Time.deltaTime;
        previous = other.GetComponent<Rigidbody>().position.z;

        float this_velocity = Mathf.Sqrt(Mathf.Pow(velocity,2f));
         

        if (this_velocity < 1)
        {
            // disable the whole GameObject
            gameObject.SetActive(false);

            Debug.Log("Collision!");
            Debug.Log(this_velocity);

            // play the collect sound (at the same position as the target, 100% volume)
            AudioSource.PlayClipAtPoint(soundTrigger, transform.position, 1.0f);
        }
    }
}

