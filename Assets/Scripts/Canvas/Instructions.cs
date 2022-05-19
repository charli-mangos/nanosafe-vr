using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Instructions : MonoBehaviour
{
    //Instructions panel
    public InstructionUnit[] inst;
    private static List<InstructionUnit> unanswered;

    //Current instruction active
    private InstructionUnit currentInst;

    // Start is called before the first frame update
    void Start()
    {
        if (unanswered == null || unanswered.Count == 0)
        {
            unanswered = inst.ToList<InstructionUnit>();
        }

        setNextInstructions();
    }


    public void setNextInstructions()
    {
        currentInst = unanswered[0];

        foreach (var palID in currentInst.description)
        {
            currentInst.canvasText.text = currentInst.canvasText.text + MainTranslate.Fields[palID] + "\n" + "\n";
        }

        currentInst.panel.SetActive(true);

        if (currentInst.isTemporary)
        {
            StartCoroutine(DestroyInstruction());
        }
    }

    public void finishInstruction()
    {
        currentInst.isCompleted = true;

        if (currentInst != null)
        {
            currentInst.panel.SetActive(false);
            unanswered.Remove(currentInst);
        }

        if(unanswered.Count > 0)
        {
            setNextInstructions();
        }
    }

    IEnumerator DestroyInstruction()
    {
        yield return new WaitForSeconds(3f);

        finishInstruction();
    }
}
