using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChangeMaterial : MonoBehaviour
{

    //New material component
    public Material newTexture;

    //Old material component
    public Material oldTexture;

    //Object to change material
    public GameObject objToChange;

    public void ChangeMat()
    {
        Renderer rend = objToChange.GetComponent<Renderer>();

        if (rend != null)
        {
            rend.material = newTexture;
        }
    }

    public void ReverseMaterial()
    {

        Renderer rend = objToChange.GetComponent<Renderer>();

        if (rend != null)
        {
            rend.material = oldTexture;
        }

    }

}
