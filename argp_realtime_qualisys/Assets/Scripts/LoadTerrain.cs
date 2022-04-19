using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;

using UXF;

public class LoadTerrain : MonoBehaviour
{

    public TextAsset all_terrain_load_list;
    
    public void BuildTerrainFeatures()
    {
        Debug.Log("In BuildTerrainFeatures!");
        // Get file name from the world
        //string file_name = all_terrain_load_list.settings.GetString("File_Name");
        //Debug.Log(file_name);

        //TextAsset terrain_file = Resources.Load<TextAsset>(file_name);

        // split up the data by line
        string[] load_info = all_terrain_load_list.text.Split(new char[] { '\n' });

        //for (int i = 1; i < load_info.Length -1; i++)
        for (int i = 1; i < 216; i++)
        {
            Debug.Log("Loading Target ID = " + i.ToString());

            // Split up text by commas to give us each column
            string[] col = load_info[i].Split(new char[] { ',' } );

            if (col[3] == "C10")
            {
                GameObject terrain_prefab = Resources.Load("Target_10") as GameObject;
                GameObject terrain_prefab_live = Instantiate(terrain_prefab) as GameObject;
                // position object
                terrain_prefab_live.transform.position = new Vector3(float.Parse(col[0]),float.Parse(col[1]),float.Parse(col[2]));
                // rename the object
                terrain_prefab_live.name = col[4];

            }

            if (col[3] == "C80")
            {
                GameObject terrain_prefab = Resources.Load("Target_80") as GameObject;
                GameObject terrain_prefab_live = Instantiate(terrain_prefab) as GameObject;
                // position object
                terrain_prefab_live.transform.position = new Vector3(float.Parse(col[0]),float.Parse(col[1]),float.Parse(col[2]));
                // rename the object
                terrain_prefab_live.name = col[4];

            }

            if (col[3] == "O")
            {
                GameObject terrain_prefab = Resources.Load("Distractor") as GameObject;
                GameObject terrain_prefab_live = Instantiate(terrain_prefab) as GameObject;
                // position object
                terrain_prefab_live.transform.position = new Vector3(float.Parse(col[0]),float.Parse(col[1]),float.Parse(col[2]));
                // rename the object
                terrain_prefab_live.name = col[4];

            }
 
        }

        Debug.Log("Done Loading Terrain Features");

    }

    // Update is called once per frame
    public void MoveTerrainFeatures(Trial trial)
    {
        Debug.Log("In MoveTerrainFeatures!");
        //will need to add a boolean to choos between "File" and the "Mirror"ed file        
        string file_name_str = trial.settings.GetString("File");

        TextAsset terrain_info = Resources.Load<TextAsset>(file_name_str);

        // get the positions of each of the projectors
        var Projector1_Pos_XYZ = GameObject.Find("CamProjector1").transform.position;
        var Projector2_Pos_XYZ = GameObject.Find("CamProjector2").transform.position;
        var Projector3_Pos_XYZ = GameObject.Find("CamProjector3").transform.position;


        string[] terrain_info_rows = terrain_info.text.Split(new char[] { '\n' });

        // Loop through the length of the list and create game objects
        // subtract 1 from length because Unity reads in an empty line at the end
        // start at i = 1 because we're giving our csv a header
        for (int i = 1; i < terrain_info_rows.Length -1; i++)
        {
            // Split up text by commas to give us each column
            string[] col_fn = terrain_info_rows[i].Split(new char[] { ',' } );

            // get the prefab ID
            string prefab_id = col_fn[6];
            GameObject this_prefab = GameObject.Find(prefab_id);

            if(col_fn[5] == "P1")
            {
                this_prefab.transform.position = new Vector3(float.Parse(col_fn[0])+Projector1_Pos_XYZ[0],0.0f,float.Parse(col_fn[2])+Projector1_Pos_XYZ[2]);
            }

            if(col_fn[5] == "P2")
            {
                this_prefab.transform.position = new Vector3(float.Parse(col_fn[0])+Projector2_Pos_XYZ[0],0.0f,float.Parse(col_fn[2])+Projector2_Pos_XYZ[2]);
            }

            if(col_fn[5] == "P3")
            {
                this_prefab.transform.position = new Vector3(float.Parse(col_fn[0])+Projector3_Pos_XYZ[0],0.0f,float.Parse(col_fn[2])+Projector3_Pos_XYZ[2]);
            }
                

            
            this_prefab.transform.Rotate(0f,float.Parse(col_fn[4]),0.0f);

            Debug.Log("idXYZ :: " + prefab_id + this_prefab.transform.position);


        } 

    }  

    public void ResetTerrainFeatures(Trial trial)
    {
        Debug.Log("In ResetTerrainFeatures!");
        //will need to add a boolean to choos between "File" and the "Mirror"ed file        
        string file_name_str = trial.settings.GetString("File");

        TextAsset terrain_info = Resources.Load<TextAsset>(file_name_str);

        string[] terrain_info_rows = terrain_info.text.Split(new char[] { '\n' });

        for (int i = 1; i < terrain_info_rows.Length -1; i++)
        {
            // Split up text by commas to give us each column
            string[] col_fn = terrain_info_rows[i].Split(new char[] { ',' } );

            string prefab_id = col_fn[6];
            GameObject this_prefab = GameObject.Find(prefab_id);
            this_prefab.transform.position = new Vector3(0f,-10f,0f);

        }  
    }
        
    
}
