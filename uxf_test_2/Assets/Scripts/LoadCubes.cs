using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCubes : MonoBehaviour
{
    public GameObject CubeRed;
    public GameObject CubeBlue;

    private var thisBlueCube;
    private var thisRedCube;
    private Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        // step 1: generate some cubes

        thisRedCube = CubeRed;
        thisBlueCube = CubeBlue;

        for(int i = 1; i < 4; i++)
        {   
            
            if(i == 1)
            {
                Instantiate(thisRedCube);
                thisRedCube.transform.position = new Vector3(1,0,1);
            }

            if(i == 3)
            {
                Instantiate(thisRedCube);
                thisRedCube.transform.position = new Vector3(-1,0,-1);
            }

            if(i == 2)
            {
                Instantiate(thisBlueCube);
                thisBlueCube.transform.position = new Vector3(1,0,0);
            }
             
        }

    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Debug.Log("Space! The Final Frontier!");

            Destroy(thisBlueCube);
        }
    }

}
