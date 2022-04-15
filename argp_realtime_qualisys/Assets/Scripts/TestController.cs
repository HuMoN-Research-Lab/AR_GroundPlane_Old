using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class TestController : MonoBehaviour
{
    public Session session;
    
    int counter = 0;

    private void OnTriggerEnter(Collider other)
    {

        if(other.name == "Hit_Box_Left" & !session.InTrial)
        {
            session.BeginNextTrial();
            counter ++;
            Debug.Log("Trial Started");
            Debug.Log(counter);
        }

        if(other.name == "Hit_Box_Right" & session.InTrial)
        {
            session.EndCurrentTrial();
            Debug.Log("Trial Ended");
        }

    }
}
