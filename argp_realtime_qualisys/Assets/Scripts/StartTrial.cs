using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class StartTrial : MonoBehaviour
{
    public Session session;
    void OnTriggerEnter(Collider other)
    {
        if(!session.InTrial)
        {
            Debug.Log(other.name);

            session.BeginNextTrial();
        }
    }
    
}
