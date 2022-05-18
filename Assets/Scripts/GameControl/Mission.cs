using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    //Turns true if mission is completed
    public bool isCompleted = false;

    //Turns true when mission begin
    private bool isStarted = false;

    //Y value of signal
    public float highVal;

    //Signal gameObject
    public GameObject prefabSignal;
    private GameObject signal;

    //Canvas element
    public GameObject canvas;

    //Is called when mission started
    public void initMission()
    {
        isStarted = true;

        //Instantiate warning signal
        if (signal == null)
        {
            signal = Instantiate(prefabSignal, new Vector3(this.transform.position.x, highVal, this.transform.position.z), Quaternion.identity) as GameObject;
            signal.transform.parent = this.transform;
        }

        canvas.SetActive(true);

        /*if (canvas.GetComponent<Instructions>())
        {
            canvas.GetComponent<Instructions>().startInstructions = true;
            canvas.GetComponent<Instructions>().setNextInstructions();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (isCompleted)
        {
            //Destroy warning signal
            canvas.SetActive(false);

            Destroy(signal, 1f);
        }
        else if (isStarted)
        {
            //Check mission targets 
        }
    }
}
