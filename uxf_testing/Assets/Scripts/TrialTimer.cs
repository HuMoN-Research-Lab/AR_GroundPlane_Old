using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class TrialTimer : MonoBehaviour
{
    public Session session;
    private float trialStartTime;
    private float trialEndTime;
    private float trialLength;

    Vector3 audioHome;

    public AudioClip trialTooSlowSound;

    public AudioClip trialTimeGoodSound;

    public int trialTimeThreshold;

    public void StartTrialTimer()
    { 
        trialStartTime = Time.time;
        Debug.Log("TrialTimer Start Time" + trialStartTime);
    }

    public void EndTrialTimer()
    {   
        // a place for the sound to play from
        audioHome = new Vector3(0.0f,0.0f,0.0f);

        trialEndTime = Time.time;

        trialLength = trialEndTime - trialStartTime;

        if(trialLength > trialTimeThreshold)
        {
            session.CurrentTrial.result["trial_time"] = "slow";

            AudioSource.PlayClipAtPoint(trialTooSlowSound,audioHome,1.0f);

            Debug.Log("TrialTimer End Time, Miss" + trialLength);

        }

        if(trialLength <= trialTimeThreshold)
        {
            session.CurrentTrial.result["trial_time"] = "good";

            AudioSource.PlayClipAtPoint(trialTimeGoodSound,audioHome,1.0f);

            Debug.Log("TrialTimer End Time, good" + trialLength);
        }
    }


}
