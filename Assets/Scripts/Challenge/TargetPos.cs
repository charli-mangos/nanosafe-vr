using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetPos : MonoBehaviour
{
    //Possible objs to select
    public GameObject[] targetObjects;
    public List<GameObject> targetList;

    public Instructions instr;

    //Panel objects
    public GameObject nextPanel;
    public GameObject prevPanel;

    // Start is called before the first frame update
    void Start()
    {
        InitList();
    }

    void InitList()
    {
        if (targetList == null || targetList.Count == 0)
        {
            targetList = targetObjects.ToList<GameObject>();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(targetList != null && targetList.Count > 0)
        {
            if (targetList.Contains(col.gameObject))
            {
                targetList.Remove(col.gameObject);

                if (targetList.Count == 0)
                {
                    finishTask();
                }
            }
        }
    }

    public void finishTask()
    {
        prevPanel.SetActive(false);
        nextPanel.SetActive(true);

        instr.finishInstruction();

        this.enabled = false;
    }
}
