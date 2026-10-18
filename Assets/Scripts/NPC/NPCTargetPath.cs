using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Linq;

public class NPCTargetPath : MonoBehaviour
{
    //Target points panel
    public NPCTargetPoints[] points;
    private List<NPCTargetPoints> notReached;

    //Current target point active
    private NPCTargetPoints currentPoint;

    public NPCFollow followComp;

    //Nav mesh agent
    private NavMeshAgent nav;

    void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();

        if (notReached == null || notReached.Count == 0)
        {
            notReached = points.ToList<NPCTargetPoints>();
        }
    }

    public void SetDestination()
    {
        if (currentPoint != null)
        {
            Destroy(currentPoint.target.gameObject);
        }

        currentPoint = notReached[0]; 
        
        if (followComp)
        {
            followComp.isLooking = false;
        }

        this.gameObject.GetComponent<Animator>().Play(currentPoint.moveAnimation);

        nav.SetDestination(currentPoint.target.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (nav.hasPath && nav.remainingDistance < nav.stoppingDistance && nav.remainingDistance != Mathf.Infinity)
        {
            this.gameObject.GetComponent<Animator>().Play(currentPoint.stopAnimation);

            notReached.Remove(currentPoint);
        }
    }
}
