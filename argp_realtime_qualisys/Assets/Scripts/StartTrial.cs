using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class StartTrial : MonoBehaviour
{
    public Session session;
    void OnTriggerEnter()
    {
        if(!session.InTrial)
        {
            session.BeginNextTrial();
        }
    }
    
}
