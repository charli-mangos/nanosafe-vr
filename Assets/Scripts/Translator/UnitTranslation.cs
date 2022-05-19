using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitTranslation : MonoBehaviour
{
    public string TextId;

    public string extraTextID;

    public string extraText;

    public bool nextLine = false;

    // Use this for initialization
    void Start()
    {
        Text text = GetComponent<Text>();
        if (text != null)
        {
            if (TextId == "ISOCode")
            {
                text.text = MainTranslate.GetLanguage();
            }
            else
            {
                text.text = MainTranslate.Fields[TextId];
            }

            if (extraText != null && nextLine == false)
            {
                text.text = text.text + " " + extraText;
            }
            else if(nextLine == true)
            {
                text.text = text.text + "\n" + "\n" + MainTranslate.Fields[extraTextID];
            }
        }
    }

}
