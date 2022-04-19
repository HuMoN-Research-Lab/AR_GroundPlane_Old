using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class RecordGameObjects : MonoBehaviour
{
    public void RecordAllObjects(Trial trial)
    {
        Dictionary<string, object> dictAllObjects = new Dictionary<string, object>();

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Collectable");

        Debug.Log(allObjects.Length);

        foreach(GameObject go in allObjects)
        {
            string go_string = go.ToString();

            Debug.Log(go_string);

            //GameObject thisGO = GameObject.Find(go_string);

            //Debug.Log(thisGO);

            Vector3 go_pos = go.transform.position;

            string go_pos_str = go_pos.ToString();
            
            Debug.Log(go_pos_str);

            dictAllObjects.Add(go_pos_str,go);

            
        }

        Debug.Log("List Start");
        Debug.Log(dictAllObjects);
        Debug.Log("List End");
        trial.SaveJSONSerializableObject(dictAllObjects, "all_object_locations");

    }

}
