using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishAnimation : MonoBehaviour
{
    //Instruction manager
    public GameObject instrManager;

    //Animation name
    public string animationName;

    //GameController element
    public GameController controller;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Animator>())
        {
            if (animationName != null)
            {
                col.gameObject.GetComponent<Animator>().Play(animationName);
            }

            if (instrManager)
            {
                if (instrManager.GetComponent<ChangeMaterial>())
                {
                    instrManager.GetComponent<ChangeMaterial>().ChangeMat();
                }

                instrManager.GetComponent<Instructions>().finishInstruction();
            }

            if (controller)
            {
                controller.finishMission();
            }

            Destroy(this);
        }

        
    }
}
