using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectItem : MonoBehaviour
{
    //Possible objs to select
    public Selectable[] selectObjs;
    public static List<Selectable> totalSelectables;

    //List of selected objs
    private List<Selectable> selected;

    //Total of needed elements
    private int totalNeeded = 0;

    //Loading element
    public GameObject loadingImg;

    //Btn gameobjects
    public GameObject checkPanel;
    public GameObject congratsPanel;
    public GameObject failPanel;

    //Check bool
    private bool fail;

    // Start is called before the first frame update
    void Start()
    {
        InitLists();
        InitHighight();
    }

    void Update()
    {
        if(selected.Count == totalNeeded)
        {
            BlockHighlight();
        }
    }

    public void InitHighight()
    {
        foreach(Selectable sel in totalSelectables)
        {
            sel.objSelectable.GetComponent<Highlight>().enabled = true;
        }
    }

    public void BlockHighlight()
    {
        foreach (Selectable sel in totalSelectables)
        {
            sel.objSelectable.GetComponent<Highlight>().enabled = false;
        }
    }

    public void InitLists()
    {
        //Init conditions
        fail = false;
        totalNeeded = 0;

        //Activate check button
        checkPanel.SetActive(true);
        failPanel.SetActive(false);
        congratsPanel.SetActive(false);

        if (totalSelectables == null || totalSelectables.Count == 0)
        {
            totalSelectables = selectObjs.ToList<Selectable>();
        }

        foreach (Selectable element in totalSelectables)
        {
            element.objSelectable.SetActive(true);

            if (element.isNeeded)
            {
                totalNeeded += 1;
            }
        }

        selected = new List<Selectable>();
    }

    public void selectObject(GameObject obj)
    {
        if(totalSelectables.Count > 0 && totalNeeded > selected.Count)
        {
            foreach (var element in totalSelectables)
            {
                if (element.objSelectable == obj)
                {
                    selected.Add(element);

                    obj.SetActive(false);

                }

                StartCoroutine(InstantiateObj(obj));
            }
        }

    }

    public void checkSelection()
    {
        if(selected.Count < totalNeeded || totalNeeded < selected.Count)
        {
            StartCoroutine(failedMission());
        }
        else
        {
            foreach (Selectable element in selected)
            {
                int index = totalSelectables.IndexOf(element);

                if (totalSelectables[index] == element)
                {
                    if (totalSelectables[index].isNeeded == false)
                    {
                        fail = true;

                        break;
                    }
                }
            }

            if (selected.Count == 0 || fail == true)
            {
                StartCoroutine(failedMission());
            }
            else
            {
                StartCoroutine(completedMission());
            }
        }

    }

    IEnumerator failedMission()
    {
        yield return new WaitForSeconds(2f);

        loadingImg.SetActive(false);

        checkPanel.SetActive(false);
        congratsPanel.SetActive(false);
        failPanel.SetActive(true);
    }

    IEnumerator completedMission()
    {
        yield return new WaitForSeconds(2f);

        loadingImg.SetActive(false);

        checkPanel.SetActive(false);
        congratsPanel.SetActive(true);
        failPanel.SetActive(false);
    }

    IEnumerator InstantiateObj(GameObject obj)
    {
        yield return new WaitForSeconds(0.05f);

        if (this.gameObject.GetComponent<InstantiateObj>())
        {
            this.gameObject.GetComponent<InstantiateObj>().AddObj(obj);
        }
    }

    /*IEnumerator RemoveObj()
    {
        yield return new WaitForSeconds(0.05f);

        if (this.gameObject.GetComponent<InstantiateObj>())
        {
            this.gameObject.GetComponent<InstantiateObj>().RemoveObj();
        }
    }*/
}
