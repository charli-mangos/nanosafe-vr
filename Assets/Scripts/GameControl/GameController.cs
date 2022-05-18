using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour
{
    public Mission[] missions;
    private static List<Mission> uncompleted;

    //Current mission active
    private Mission currentMission;

    public bool startScene = false;

    // Start is called before the first frame update
    void Start()
    {
        if (uncompleted == null || uncompleted.Count == 0)
        {
            uncompleted = missions.ToList<Mission>();

            foreach (var mis in uncompleted)
            {
                if (mis.isCompleted)
                {
                    uncompleted.Remove(mis);
                }
            }
        }
    }

    public void setNextMission()
    {
        currentMission = uncompleted[0];

        currentMission.gameObject.SetActive(true);

        currentMission.initMission();
    }

    public void finishMission()
    {
        currentMission.isCompleted = true;

        if (currentMission != null)
        {
            uncompleted.Remove(currentMission);
        }

        if(uncompleted.Count > 0)
        {
            setNextMission();
        }
    }

}
