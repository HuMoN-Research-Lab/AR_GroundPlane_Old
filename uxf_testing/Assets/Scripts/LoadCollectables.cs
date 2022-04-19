using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;
using System.IO;

public class LoadCollectables : MonoBehaviour
{  
    public TextAsset initial_load_list;

    public TextAsset instantiate_list;

    public void InstantiateCollectables()
    {   
        Debug.Log("In InstantiateCollectables");

        // split up the data by line
        string[] load_info = instantiate_list.text.Split(new char[] { '\n' });

        for (int i = 1; i < load_info.Length -1; i++)
        {
            string[] col = load_info[i].Split(new char[] { ',' } );
            
            GameObject this_prefab = Resources.Load ("Collectable 1") as GameObject;
            GameObject generic_collectable = Instantiate(this_prefab) as GameObject;

            generic_collectable.transform.position = new Vector3(float.Parse(col[0]),float.Parse(col[1]),float.Parse(col[2]));
        }
    }


    //public GameObject collectable;
    public void BuildCollectables()
    {
        Debug.Log("Hello there 'Build Collectables' ");

        // split up the data by line
        string[] load_info = initial_load_list.text.Split(new char[] { '\n' });

        for (int i = 1; i < load_info.Length -1; i++)
        {
            // Split up text by commas to give us each column
            string[] col = load_info[i].Split(new char[] { ',' } );

            if (col[3] == "C1")
            {
                GameObject prefab_collectable = Resources.Load("Collectable 1") as GameObject;
                GameObject generic_collectable = Instantiate(prefab_collectable) as GameObject;
                // position object
                generic_collectable.transform.position = new Vector3(float.Parse(col[0]),float.Parse(col[1]),float.Parse(col[2]));
                // rename the object
                generic_collectable.name = col[4];

            }

            if (col[3] == "C2")
            {
                GameObject prefab_collectable = Resources.Load("Collectable 2") as GameObject;
                GameObject generic_collectable = Instantiate(prefab_collectable) as GameObject;
                // position object
                generic_collectable.transform.position = new Vector3(float.Parse(col[0]),float.Parse(col[1]),float.Parse(col[2]));
                // rename the object
                generic_collectable.name = col[4];

            }
 
        }

    }
    
    public void MoveCollectables(Trial trial)
    {
        Debug.Log("Hello there 'Move Collectables' ");
        
        string file_name_str = trial.settings.GetString("File");

        Debug.Log(file_name_str);

        TextAsset trial_info = Resources.Load<TextAsset>(file_name_str);

        string[] file_name_rows = trial_info.text.Split(new char[] { '\n' });

        for (int i = 1; i < file_name_rows.Length -1; i++)
        {
            // Split up text by commas to give us each column
            string[] col_fn = file_name_rows[i].Split(new char[] { ',' } );

            string prefab_id = col_fn[4];
            GameObject this_collectable = GameObject.Find(prefab_id);
            this_collectable.transform.position = new Vector3(float.Parse(col_fn[0]),0.3f,float.Parse(col_fn[2]));

            Debug.Log("idXYZ :: " + prefab_id + this_collectable.transform.position);


        }   

    }

    public void ResetCollectables(Trial trial)
    {
        string file_name_str = trial.settings.GetString("File");

        TextAsset trial_info = Resources.Load<TextAsset>(file_name_str);

        string[] file_name_rows = trial_info.text.Split(new char[] { '\n' });

        for (int i = 1; i < file_name_rows.Length -1; i++)
        {
            // Split up text by commas to give us each column
            string[] col_fn = file_name_rows[i].Split(new char[] { ',' } );

            string prefab_id = col_fn[4];
            GameObject this_collectable = GameObject.Find(prefab_id);
            this_collectable.transform.position = new Vector3(0f,-10f,0f);

        }  
    }
    
}
