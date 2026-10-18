using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class NPCTargetPoints
{
    //Target point to move
    public Transform target;

    //Animation for moving 
    public string moveAnimation;

    //Animation for stopping
    public string stopAnimation;

    //Check if position is reached
}
