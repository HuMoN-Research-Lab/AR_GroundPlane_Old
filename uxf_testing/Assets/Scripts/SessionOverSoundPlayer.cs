using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class SessionOverSoundPlayer : MonoBehaviour
{
public Session session;
Vector3 audioHome;
public AudioClip SessionOverSound;

public void SessionOverSounder()
{
    // a place for the sound to play from
    audioHome = new Vector3(0.0f,0.0f,0.0f);

    AudioSource.PlayClipAtPoint(SessionOverSound,audioHome,1.0f);

}
    
}
