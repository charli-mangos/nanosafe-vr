using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChangeTexture : MonoBehaviour
{

    //New material component
    public Texture newTexture;

    //Old material component
    public Texture oldTexture;

    //Object to change material
    public GameObject objToChange;


    public void ChangeMat()
    {
        List<Material> myMaterials = objToChange.GetComponent<Renderer>().materials.ToList();

        int i = 0;
        foreach (var ele in myMaterials)
        {

            if (ele.GetTexture("_BaseMap") == oldTexture)
            {
                ele.SetTexture("_BaseMap", newTexture);
            }

            i++;
        }
    }

    public void ReverseMaterial()
    {
        List<Material> myMaterials = objToChange.GetComponent<Renderer>().materials.ToList();

        int i = 0;
        foreach (var ele in myMaterials)
        {

            if (ele.GetTexture("_BaseMap") == newTexture)
            {
                ele.SetTexture("_BaseMap", oldTexture);
            }

            i++;
        }
    }

}