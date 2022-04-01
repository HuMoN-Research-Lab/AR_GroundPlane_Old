﻿using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;

public class LoadTerrain : MonoBehaviour
{
    //public Vector3 Projector1_Pos_XYZ;
    // Start is called before the first frame update
    
    void Start()
    {
        // get the positions of each of the projectors
        var Projector1_Pos_XYZ = GameObject.Find("CamProjector1").transform.position;
        var Projector2_Pos_XYZ = GameObject.Find("CamProjector2").transform.position;
        var Projector3_Pos_XYZ = GameObject.Find("CamProjector3").transform.position;

        // Load in terrain csv
        TextAsset terrain_file = Resources.Load<TextAsset>("terrain_test");

        // split up the data by line
        string[] terrain_info = terrain_file.text.Split(new char[] { '\n' });

        // Loop through the length of the list and create game objects
        // subtract 1 from length because Unity reads in an empty line at the end
        // start at i = 1 because we're giving our csv a header
        Debug.Log(terrain_info.Length);
        for (int i = 1; i < terrain_info.Length -1; i++)
        {   
            // Split up terrain by commas to give us each column
            string[] col = terrain_info[i].Split(new char[] { ',' } );

            // generate a game object based on the information in col
            if (col[3] == "O")
            {
                GameObject prefab_distractor = Resources.Load ("Distractor") as GameObject;
                GameObject distractor = Instantiate(prefab_distractor) as GameObject;
                 
                if(col[5] == "P1")
                {
                    // add the x,z position of the appropriate camera to the position of the game object
                    distractor.transform.position = new Vector3(float.Parse(col[0])+Projector1_Pos_XYZ[0],0,float.Parse(col[2])+Projector1_Pos_XYZ[2] );
                    
                }

                if(col[5] == "P2")
                {
                    // add the x,z position of the appropriate camera to the position of the game object
                    distractor.transform.position = new Vector3(float.Parse(col[0])+Projector2_Pos_XYZ[0],0,float.Parse(col[2])+Projector2_Pos_XYZ[2] );
                    
                }

                if(col[5] == "P3")
                {
                    // add the x,z position of the appropriate camera to the position of the game object
                    distractor.transform.position = new Vector3(float.Parse(col[0])+Projector3_Pos_XYZ[0],0,float.Parse(col[2])+Projector3_Pos_XYZ[2] );
                    
                }

            }

            if (col[3] == "C10")
            {
                GameObject prefab_target_10 = Resources.Load ("Target_10") as GameObject;
                GameObject target_10 = Instantiate(prefab_target_10) as GameObject;
                target_10.transform.Rotate(0,float.Parse(col[4]),0);

                if(col[5] == "P1")
                {
                    // add the x,z position of the appropriate camera to the position of the game object
                    target_10.transform.position = new Vector3(float.Parse(col[0])+Projector1_Pos_XYZ[0],0,float.Parse(col[2])+Projector1_Pos_XYZ[2] );
                    
                }

                if(col[5] == "P2")
                {
                    // add the x,z position of the appropriate camera to the position of the game object
                    target_10.transform.position = new Vector3(float.Parse(col[0])+Projector2_Pos_XYZ[0],0,float.Parse(col[2])+Projector2_Pos_XYZ[2] );
                    
                }

                if(col[5] == "P3")
                {
                    // add the x,z position of the appropriate camera to the position of the game object
                    target_10.transform.position = new Vector3(float.Parse(col[0])+Projector3_Pos_XYZ[0],0,float.Parse(col[2])+Projector3_Pos_XYZ[2] );
                    
                }
            }

            if (col[3] == "C80")
            {
                GameObject prefab_target_80 = Resources.Load ("Target_80") as GameObject;
                GameObject target_80 = Instantiate(prefab_target_80) as GameObject;
                target_80.transform.Rotate(0,float.Parse(col[4]),0);

                if(col[5] == "P1")
                {
                    // add the x,z position of the appropriate camera to the position of the game object
                    target_80.transform.position = new Vector3(float.Parse(col[0])+Projector1_Pos_XYZ[0],0,float.Parse(col[2])+Projector1_Pos_XYZ[2] );
                    
                }

                if(col[5] == "P2")
                {
                    // add the x,z position of the appropriate camera to the position of the game object
                    target_80.transform.position = new Vector3(float.Parse(col[0])+Projector2_Pos_XYZ[0],0,float.Parse(col[2])+Projector2_Pos_XYZ[2] );
                    
                }

                if(col[5] == "P3")
                {
                    // add the x,z position of the appropriate camera to the position of the game object
                    target_80.transform.position = new Vector3(float.Parse(col[0])+Projector3_Pos_XYZ[0],0,float.Parse(col[2])+Projector3_Pos_XYZ[2] );
                    
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
