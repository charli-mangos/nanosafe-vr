using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObj : MonoBehaviour
{

    //Obj to instantiate
    public GameObject instantiatePrefab;
    private GameObject instantiateOBJ;

    public GameObject parentOBJ;

    public void AddObj(GameObject obj)
    {
        if(instantiateOBJ == null && instantiatePrefab != null)
        {
            instantiateOBJ = Instantiate(instantiatePrefab, obj.transform.position, obj.transform.rotation) as GameObject;
            instantiateOBJ.transform.parent = parentOBJ.transform;
        }
    }

    public void RemoveObj()
    {
        Destroy(instantiateOBJ);
    }
}
