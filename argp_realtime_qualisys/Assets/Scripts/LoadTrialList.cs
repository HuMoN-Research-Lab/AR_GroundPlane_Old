using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class LoadTrialList : MonoBehaviour
{
    public int trial_number;
    public string current_trial_file;

    public bool mirrored; // is the trial mirrored or not

    void Start()
    {
        trial_number = 1;
    }
    public void LoadTrials()
    { 
        // Load in trial list csv
        TextAsset trial_list = Resources.Load<TextAsset>("sub01_trial_list");
        // split up the data by line
        string[] trial_list_rows = trial_list.text.Split(new char[] { '\n' });
        // Split up trial line by commas to give us each column
        string[] trial_column = trial_list_rows[trial_number].Split(new char[] { ',' } );

        // Load in trial list csv
        TextAsset mirrored_trial_list = Resources.Load<TextAsset>("sub01_mirrored_trial_list");
        // split up the data by line
        string[] mirrored_trial_list_rows = mirrored_trial_list.text.Split(new char[] { '\n' });
        // Split up trial line by commas to give us each column
        string[] mirrored_trial_column = mirrored_trial_list_rows[trial_number].Split(new char[] { ',' } );
    
        if (mirrored == false)
        {
            current_trial_file = trial_column[1];
        }

        if (mirrored == true)
        {
            current_trial_file = mirrored_trial_column[1];
        }
        
    
    }

}
