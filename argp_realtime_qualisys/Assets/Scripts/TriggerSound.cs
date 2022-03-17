using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    // reference to the AudioClip we want to play on trigger enter.
    public AudioClip soundTrigger;

    /// OnTriggerEnter is called when the Collider 'other' enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "L-Frame O")
        {
            // disable the whole GameObject
            gameObject.SetActive(false);

            Debug.Log("Collision!");

            // play the collect sound (at the same position as the target, 100% volume)
            AudioSource.PlayClipAtPoint(soundTrigger, transform.position, 1.0f);
        }
    }
}