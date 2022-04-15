using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class LoadCollectables : MonoBehaviour
{
    public void GenerateCollectables(Trial trial)
    {
        TextAsset file_name = Resources.Load<TextAsset>("trial_list_uxf_testing.csv");

        Debug.Log("Hello there 'GenerateCollectables' ");
        Debug.Log(trial.settings.GetFloat("X"));

        GameObject prefab_collectable = Resources.Load("Collectable") as GameObject;
        GameObject collectable = Instantiate(prefab_collectable) as GameObject;

        collectable.transform.position = new Vector3(trial.settings.GetFloat("X"), trial.settings.GetFloat("Y"), trial.settings.GetFloat("Z"));        

    }
    
}
