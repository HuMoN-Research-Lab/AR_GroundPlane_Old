using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCleanup : MonoBehaviour
{
    public void DestroyThisObject()
    {
    Debug.Log("KABOOM - game object destroyed");

    DestroyImmediate(gameObject, true);    
    //Destroy(gameObject);
    }
}
